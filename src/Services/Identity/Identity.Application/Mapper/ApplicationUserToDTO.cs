using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Models;

namespace Identity.Application.Mapper;

public class ApplicationUserToDTO : Profile
{
    public ApplicationUserToDTO()
    {
        CreateMap<ApplicationUser, UserDTO>();
    }
}
