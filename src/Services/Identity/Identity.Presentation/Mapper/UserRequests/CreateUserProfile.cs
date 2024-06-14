using AutoMapper;
using Identity.Application.UseCases.UserCrud.CreateUser;
using Identity.Presentation.Requests.UserRequests;

namespace Identity.Presentation.Mapper.UserRequests;
public class CreateUserProfile : Profile
{
    public CreateUserProfile()
    {
        CreateMap<CreateUserRequest, CreateUserUseCase>();
    }
}