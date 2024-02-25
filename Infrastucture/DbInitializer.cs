using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastucture.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture
{
    public class DbInitializer : IDbInitializer
    {
        private readonly AppDBContext _сontext;
        
        public DbInitializer(AppDBContext context)
        {
            _сontext = context;
        }

        public async Task Initialize()
        {
            // Удаление данных из таблиц
            var tableNames = _сontext.Model.GetEntityTypes()
              .Select(t => t.GetTableName())
              .Distinct()
              .ToList();

            foreach (var tableName in tableNames)
            {
                _сontext.Database.ExecuteSqlRaw($"TRUNCATE public.\"{tableName}\" CASCADE;");
            }

            int depCount = 1;
            int ofCount = 1;
            for (int c = 1; c < 3; c++)
            {
                await _сontext.AddAsync(new Company
                {
                    Id = c,
                    Name = $"Компания {c}"
                });
                await _сontext.SaveChangesAsync();
                
                for (int d = 1; d < 4; d++)
                {
                    await _сontext.AddAsync(new Department
                    {
                        Id = depCount,
                        Name = $"Департамент {depCount}",
                        CompanyId = c
                    });
                    await _сontext.SaveChangesAsync();
                    for (int of = 1; of < 4; of++)
                    {
                        await _сontext.AddAsync(new Office
                        {
                            Id = ofCount,
                            Name = $"Отдел {ofCount}",
                            DepartmentId = depCount
                        });
                        ofCount++;
                        await _сontext.SaveChangesAsync();
                    }
                    depCount++;
                }
            } 
        }
    }
}
