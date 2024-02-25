using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface IOfficeService
    {
        Task<List<Office>> GetAllAsync();
        Task<Office> GetByIdAsync(int id);
        Task AddAsync(Office office);
        Task ChangeAsync(int id, Office office);
        Task DeleteAsync(int id);
    }
}
