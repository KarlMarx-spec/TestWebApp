using Domain.Entities;

namespace Application.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompaniesWithDepartmentsAsync();
        Task<List<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(int id);
        Task AddAsync(Company company);
        Task ChangeAsync(int id, Company company);
        Task DeleteAsync(int id);
    }
}
