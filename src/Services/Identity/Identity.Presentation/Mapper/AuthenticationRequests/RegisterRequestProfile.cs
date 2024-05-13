using Identity.Presentation.Requests.AuthenticationRequests;
using AutoMapper;
using Identity.Application.UseCases.Authentication.Register;

namespace Identity.Presentation.Mapper.AuthenticationRequests;


public class RegisterRequestProfile : Profile
{
    public RegisterRequestProfile()
    {
        CreateMap<RegisterRequest, RegisterUseCase>();
    }
}