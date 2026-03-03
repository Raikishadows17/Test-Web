using Application.DTOs;
using Application.Interface.Repository.Entities;
using Application.Interface.Service;
using Application.Services.Common;
using Domain.Common;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class RolService : BaseService<RolDTO>, IRolService
    {
        private readonly IRolRepository _rolRepository;
        public RolService(IRolRepository rolRepository) : base(rolRepository)
        {
            _rolRepository = rolRepository;
        }

    }
}
