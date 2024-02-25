using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetCompaniesWithDepartmentsAsync();
        Task<List<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(int id);
        Task AddAsync(Company company);
        Task ChangeAsync(int id, Company company);
        Task DeleteAsync(int id);
    }
}
