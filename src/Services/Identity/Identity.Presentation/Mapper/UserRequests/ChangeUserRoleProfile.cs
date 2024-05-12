using AutoMapper;
using Identity.Application.UseCases.UserCrud.ChangeRole;
using Identity.Presentation.Requests.UserRequests;

namespace Identity.Presentation.Mapper.UserRequests;
public class ChangeUserRoleProfile : Profile
{
    public ChangeUserRoleProfile()
    {
        CreateMap<ChangeUserRoleRequest, ChangeUserRoleUseCase>();
    }
}
