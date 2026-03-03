using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;
using Domain.Exceptions;

namespace Application.Services
{
    public class RoadRoutesService : BaseService<RoadRoutesDTO>,IRoadRouteService
    {
        private readonly IRoadRouteRepository _roadRouteRepository;
        public RoadRoutesService(IRoadRouteRepository roadRouteRepository): base(roadRouteRepository)
        {
            _roadRouteRepository = roadRouteRepository;
        }

    }
}
