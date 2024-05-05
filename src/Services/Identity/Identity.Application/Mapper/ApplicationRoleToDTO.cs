using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Mapper
{
    public class ApplicationRoleToDTO : Profile
    {
        public ApplicationRoleToDTO()
        {
            CreateMap<ApplicationRole, RoleDTO>();
        }
    }
}
