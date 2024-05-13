using AutoMapper;
using Identity.Application.Common.Models;
using Identity.Domain.Entities;

namespace Identity.Application.Common.Mapper;

public class ApplicationRoleToDTO : Profile
{
    public ApplicationRoleToDTO()
    {
        CreateMap<ApplicationRole, RoleDTO>();
    }
}
