using Identity.Presentation.Requests.AuthenticationRequests;
using Identity.Application.UseCases.Authentication.Register;
using AutoMapper;

namespace Identity.Presentation.Mapper.AuthenticationRequests;


public class RegisterRequestProfile : Profile
{
    public RegisterRequestProfile()
    {
        CreateMap<RegisterRequest, RegisterUseCase>();
    }
}