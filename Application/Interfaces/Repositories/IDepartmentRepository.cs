using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        Task AddAsync(Department department);
        Task ChangeAsync(int id, Department department);
        Task DeleteAsync(int id);
    }
}
