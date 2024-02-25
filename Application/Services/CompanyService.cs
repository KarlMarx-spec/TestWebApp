using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class CompanyService : ICompanyService
    {
        public ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Company>> GetCompaniesWithDepartmentsAsync()
        {
            return await _repository.GetCompaniesWithDepartmentsAsync();
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Company company)
        {
            await _repository.AddAsync(company);
        }

        public async Task ChangeAsync(int id, Company company)
        {
            await _repository.ChangeAsync(id, company);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
