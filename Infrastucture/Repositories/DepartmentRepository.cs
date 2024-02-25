using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastucture.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext _context;

        public DepartmentRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeAsync(int id, Department department)
        {
            department.Id = id;
            var departmentDB = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            departmentDB.Name = department.Name;
            departmentDB.CompanyId = department.CompanyId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var departmentDB = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
            _context.Departments.Remove(departmentDB);
            await _context.SaveChangesAsync();
        }
    }
}
