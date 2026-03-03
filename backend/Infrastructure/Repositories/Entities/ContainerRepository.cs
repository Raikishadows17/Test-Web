using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entities
{
    public class ContainerRepository : CreateRepository<ContainerDTO, Container>, IContainerRepository
    {
        private readonly IDbContextFactory _dbContextFactory;
        private readonly IMapper _mapper;

        public ContainerRepository(IDbContextFactory dbContextFactory,IMapper mapper) : base(dbContextFactory,mapper)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async override Task UpdateAsync(ContainerDTO entityDto)
        {

            using var dbContext =  _dbContextFactory.CreateDbContext();

            var rowAffected = await dbContext.Containers.Where(c => c.Id == entityDto.ContainerId && c.Active)
                                                        .ExecuteUpdateAsync( c => c
                                                            .SetProperty(c => c.ContainerTypeId,entityDto.ContainerTypeId)
                                                            .SetProperty(c => c.ContainerRedId, entityDto.ContainerRedId)
                                                            .SetProperty(c => c.ShippingLineId, entityDto.ShippingLineId)
                                                            .SetProperty(c => c.Size, entityDto.Size)
                                                            .SetProperty(c => c.WeightKg, entityDto.WeightKg)
                                                            .SetProperty(c => c.ContainerNumber, entityDto.ContainerNumber)
                                                            .SetProperty(c => c.RedEntryDate, entityDto.RedEntryDate)
                                                            .SetProperty(c => c.RedLiberationDate, entityDto.RedLiberationDate)
                                                            .SetProperty(c => c.ContainerTypeName, entityDto.ContainerTypeName)
                                                            .SetProperty(c => c.CntrDocumentRecuest, entityDto.CntrDocumentRecuest)
                                                            .SetProperty(c => c.ArchieveRequest, entityDto.ArchieveRequest)
                                                            .SetProperty(c => c.CntrDocumentRfc, entityDto.CntrDocumentRfc)
                                                            .SetProperty(c => c.RfcCompany, entityDto.RfcCompany)
                                                            .SetProperty(c => c.CompanyName, entityDto.CompanyName)
                                                        );

            if (rowAffected == 0)
                throw new NotFoundException("No se aplicó la actualizacion, talvez no hay contenedor asignado al id proporcionado, contacta al administrador");

        }

    }
}
