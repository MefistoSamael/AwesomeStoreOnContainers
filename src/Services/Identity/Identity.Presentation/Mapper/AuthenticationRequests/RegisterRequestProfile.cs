using AutoMapper;
using Identity.Application.UseCases.Authentication.Register;
using Identity.Presentation.Requests.AuthenticationRequests;

namespace Identity.Presentation.Mapper.AuthenticationRequests;

public class RegisterRequestProfile : Profile
{
    public RegisterRequestProfile()
    {
        CreateMap<RegisterRequest, RegisterUseCase>();
    }
}