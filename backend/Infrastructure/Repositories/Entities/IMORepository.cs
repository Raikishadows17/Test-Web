using Application.DTOs;
using Application.Interface.Repository.Common;
using Application.Interface.Repository.Entities;
using Domain.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories.Entities
{
    public class IMORepository : GetDataRepository<IMODto,IMO> , IIMORepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public IMORepository(IDbContextFactory dbContextFactory) : base (dbContextFactory) 
        {

        }



    }
}
