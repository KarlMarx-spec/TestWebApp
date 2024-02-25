using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastucture.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly AppDBContext _context;

        public OfficeRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Office>> GetAllAsync()
        {
            return await _context.Offices.ToListAsync();
        }

        public async Task<Office> GetByIdAsync(int id)
        {
            return await _context.Offices.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Office office)
        {
            await _context.Offices.AddAsync(office);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeAsync(int id, Office office)
        {
            office.Id = id;
            var officeDB = await _context.Offices.FirstOrDefaultAsync(x => x.Id == id);
            officeDB.Name = office.Name;
            officeDB.DepartmentId = office.DepartmentId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var officeDB = await _context.Offices.FirstOrDefaultAsync(x => x.Id == id);
            _context.Offices.Remove(officeDB);
            await _context.SaveChangesAsync();
        }
    }
}
