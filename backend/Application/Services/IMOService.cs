using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class IMOService : GetDataService<IMODto> , IIMOService
    {
        private readonly IIMORepository _imoRepository;

        public IMOService(IIMORepository iMORepository) : base(iMORepository) 
        {

        }

    }
}
