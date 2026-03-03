using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;
using Domain.Exceptions;

namespace Application.Services
{
    public class LogisticsProviderService : BaseService<LogicProviderDTO> ,ILogisticsProviderService
    {
        private readonly ILogisticsProviderRepository _repository;

        public LogisticsProviderService(ILogisticsProviderRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
