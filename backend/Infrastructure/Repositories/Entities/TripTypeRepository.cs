using Application.DTOs;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Entities
{
    public class TripTypeRepository : GetDataRepository<TripTypeDTO, TripType>, ITripTypeRepository
    {
        public TripTypeRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }
    }
}
