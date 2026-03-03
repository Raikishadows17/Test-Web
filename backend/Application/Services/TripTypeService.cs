using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;

namespace Application.Services
{
    public class TripTypeService : GetDataService<TripTypeDTO>,ITripTypeService
    {
        public TripTypeService(ITripTypeRepository tripTypeService) : base(tripTypeService)
        {

        }
    }
}
