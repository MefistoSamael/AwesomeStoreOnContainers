using AutoMapper;
using Identity.Application.Common.Models;
using Identity.Domain.Models;

namespace Identity.Application.Common.Mapper;

public class ApplicationUserToDTO : Profile
{
    public ApplicationUserToDTO()
    {
        CreateMap<ApplicationUser, UserDTO>();
    }
}
