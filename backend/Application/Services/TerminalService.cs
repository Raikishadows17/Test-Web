using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;
using Domain.Exceptions;

namespace Application.Services
{
    public class TerminalService : BaseService<TerminalDTO>, ITerminalService
    {
        private readonly ITerminalRepository _terminalService;

        public TerminalService(ITerminalRepository terminalRepository):base(terminalRepository) 
        {
            _terminalService = terminalRepository;
        }       
    }
}
