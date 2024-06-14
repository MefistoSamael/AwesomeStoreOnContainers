using AutoMapper;
using Identity.Application.UseCases.Authentication.LogIn;
using Identity.Presentation.Requests.AuthenticationRequests;

namespace Identity.Presentation.Mapper.AuthenticationRequests;

public class LogInRequestProfile : Profile
{
    public LogInRequestProfile()
    {
        CreateMap<LogInRequest, LogInUseCase>();
    }
}