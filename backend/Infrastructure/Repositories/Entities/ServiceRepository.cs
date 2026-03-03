using Application.DTOs;
using Application.Interface.Repository.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entities
{
    public class ServiceRepository : CreateRepository<ServiceDTO, Domain.Entities.Service>, IServiceRepository
    {
        private IDbContextFactory _dbContextFactory;
        private IMapper _mapper;

        public ServiceRepository(IDbContextFactory dbContextFactory,IMapper mapper) : base (dbContextFactory,mapper)
        { 
            _dbContextFactory = dbContextFactory;
        }

        public async Task<ServiceOptionDTO> GetServiceCreationOptionAsync()
        {
            var imoTask = Task.Run(async () =>
            {
                using var db = _dbContextFactory.CreateDbContext();
                return await db.IMO
                    .Where(x => x.Active)
                    .ProjectToType<IMODto>()
                    .ToListAsync();
            });

            var tripTypeTask = Task.Run(async () =>
            {
                using var db = _dbContextFactory.CreateDbContext();
                return await db.TripTypes
                    .Where(x => x.Active)
                    .ProjectToType<TripTypeDTO>()
                    .ToListAsync();
            });

            var equipmentTask = Task.Run(async () =>
            {
                using var db = _dbContextFactory.CreateDbContext();
                return await db.Equipments
                    .Where(x => x.Active)
                    .ProjectToType<EquipmentDTO>()
                    .ToListAsync();
            });

            var terminalTask = Task.Run(async () =>
            {
                using var db = _dbContextFactory.CreateDbContext();
                return await db.Terminals
                    .Where(x => x.Active)
                    .ProjectToType<TerminalDTO>()
                    .ToListAsync();
            });

            var containerTask = Task.Run(async () =>
            {
                using var db = _dbContextFactory.CreateDbContext();
                return await db.Containers
                    .Where(x => x.Active)
                    .ProjectToType<ContainerDTO>()
                    .ToListAsync();
            });

            var containerTypeTask = Task.Run(async () =>
            {
                using var db = _dbContextFactory.CreateDbContext();
                return await db.ContainerTypes
                    .Where(x => x.Active)
                    .ProjectToType<ContainerTypeDTO>()
                    .ToListAsync();
            });

            var roadRoutesTask = Task.Run(async () =>
            {
                using var db = _dbContextFactory.CreateDbContext();
                return await db.RoadRoutes
                    .Where(x => x.Active)
                    .ProjectToType<RoadRoutesDTO>()
                    .ToListAsync();
            });

            var customerTask = Task.Run(async () =>
            {
                using var db = _dbContextFactory.CreateDbContext();
                return await db.Customers
                    .Where(x => x.Active)
                    .ProjectToType<CustomerDTO>()
                    .ToListAsync();
            });

            var operatorTask = Task.Run(async () =>
            {
                using var db = _dbContextFactory.CreateDbContext();
                return await db.Employees
                    .Where(e => e.Active && (e.EmployeeCategory.EmpCatId == 1 || e.EmployeeCategory.EmpCatId == 2))
                    .ProjectToType<EmployeeDTO>()
                    .ToListAsync();
            });

            await Task.WhenAll(
                imoTask, tripTypeTask, equipmentTask, terminalTask,
                containerTask, containerTypeTask, roadRoutesTask,
                customerTask, operatorTask);

            return new ServiceOptionDTO
            {
                IMO = imoTask.Result,
                TripType = tripTypeTask.Result,
                Equipment = equipmentTask.Result,
                Terminal = terminalTask.Result,
                Container = containerTask.Result,
                ContainerType = containerTypeTask.Result,
                RoadRoutes = roadRoutesTask.Result,
                Customer = customerTask.Result,
                Operator = operatorTask.Result
            };
        }

        public async override Task UpdateAsync(ServiceDTO entity)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            await dbContext.Services.Where(s => s.Id == entity.ServiceId && s.Active)
                                    .ExecuteUpdateAsync(s => s
                                         .SetProperty(p => p.EquipamentId, entity.EquipamentId)
                                        .SetProperty(p => p.ContainerId, entity.ContainerId)
                                        .SetProperty(p => p.TripTypeId, entity.TripTypeId)
                                        .SetProperty(p => p.CustomerId, entity.CustomerId)
                                        .SetProperty(p => p.StatusServiceId, entity.StatusServiceId)
                                        .SetProperty(p => p.CreationDate, entity.CreationDate)
                                        .SetProperty(p => p.UserCreation, entity.UserCreation)
                                        .SetProperty(p => p.AutorizationCCODate, entity.AutorizationCCODate)
                                        .SetProperty(p => p.AutorizationCFODate, entity.AutorizationCFODate)
                                        .SetProperty(p => p.OperatedTraffic, entity.OperatedTraffic)
                                        .SetProperty(p => p.ServiceSingleFull, entity.ServiceSingleFull)
                                    );

        }

    }
}
