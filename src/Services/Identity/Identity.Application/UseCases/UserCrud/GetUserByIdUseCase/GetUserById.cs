using Identity.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.UserCrud.GetUserByIdUseCase
{
    public class GetUserById : IRequest<UserDTO?>
    {
        public string UserId { get; set; }
    }

}
