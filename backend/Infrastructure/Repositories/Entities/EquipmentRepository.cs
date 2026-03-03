using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using MapsterMapper;

namespace Infrastructure.Repositories.Entities
{
    public class EquipmentRepository : CreateRepository<EquipmentDTO,Equipment>, IEquipmentRepository
    {
        public readonly IDbContextFactory _dbContextFactory;

        public EquipmentRepository(IDbContextFactory dbContextFactory,IMapper mapper) : base (dbContextFactory, mapper)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async override Task UpdateAsync(EquipmentDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
