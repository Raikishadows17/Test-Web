using Application.DTOs;
using Application.Interface.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface.Service
{
    public interface IServiceService : IService<ServiceDTO>
    {
        Task<ServiceOptionDTO> GetServiceCreationOptionAsync();
    }
}
