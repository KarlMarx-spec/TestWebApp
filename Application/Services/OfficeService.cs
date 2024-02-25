using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Application.Services
{
    public class OfficeService : IOfficeService
    {
        public IOfficeRepository _repository;

        public OfficeService(IOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Office>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Office> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Office office)
        {
            await _repository.AddAsync(office);
        }

        public async Task ChangeAsync(int id, Office office)
        {
            await _repository.ChangeAsync(id, office);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
