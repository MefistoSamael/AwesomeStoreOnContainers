using AutoMapper;
using Identity.Application.UseCases.Authentication.Refresh;
using Identity.Presentation.Requests.AuthenticationRequests;

namespace Identity.Presentation.Mapper.AuthenticationRequests;

public class RefreshRequestProfile : Profile
{
    public RefreshRequestProfile()
    {
        CreateMap<RefreshRequest, RefreshUseCase>();
    }
}

