using AutoMapper;
using Identity.Application.Models;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.MappingProfiles
{
    public class ApplicationUserToUserDtoMappingProfile : Profile
    {
        public ApplicationUserToUserDtoMappingProfile()
        {
            CreateMap<ApplicationUser, UserDTO>();
        }
    }
}
