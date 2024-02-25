using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastucture.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDBContext _context;

        public CompanyRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetCompaniesWithDepartmentsAsync()
        {
            return await _context.Companies
                            .Include(x => x.Departments)!
                            .ThenInclude(x => x.Offices)
                            .ToListAsync();
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeAsync(int id, Company company)
        {
            company.Id = id;
            var companyDB = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            companyDB.Name = company.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var companyDB = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            _context.Companies.Remove(companyDB);
            await _context.SaveChangesAsync();
        }
    }
}
