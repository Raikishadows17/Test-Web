using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Entities
{
    public class TerminalRepository : CreateRepository<TerminalDTO,Terminal>, ITerminalRepository
    {        
        private readonly IDbContextFactory _dbContextFactory;

        public TerminalRepository(IDbContextFactory dbContextFactory, IMapper mapper) : base(dbContextFactory,mapper)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async override Task UpdateAsync(TerminalDTO entity)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var rowAffected = await context.Terminals.Where(t => t.Id == entity.TerminalId && t.Active)
                            .ExecuteUpdateAsync(t => t
                                .SetProperty(t => t.LogisticsProviderId, entity.LogisticsProviderId)
                                .SetProperty(t => t.TerminalCode, entity.TerminalCode)
                                .SetProperty(t => t.NameTerminal, entity.NameTerminal)
                                .SetProperty(t => t.Comments, entity.Comments)
                                .SetProperty(t => t.UrlImage, entity.UrlImage));

            if(rowAffected == 0)
                throw new Exception("No se aplicó la actualización, talvez no hay terminal asignada al id proporcionado, contacta al administrador");

            await context.SaveChangesAsync();

        }


    }
}
