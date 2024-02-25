using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        Task AddAsync(Department department);
        Task ChangeAsync(int id, Department department);
        Task DeleteAsync(int id);
    }
}
