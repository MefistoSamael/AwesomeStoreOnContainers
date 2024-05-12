using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Entities;

namespace Identity.Application.Mapper;

public class ApplicationRoleToDTO : Profile
{
    public ApplicationRoleToDTO()
    {
        CreateMap<ApplicationRole, RoleDTO>();
    }
}
