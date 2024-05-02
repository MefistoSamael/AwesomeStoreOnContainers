using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.UserCrud.DeleteUserUseCase
{
    public class DeleteUser : IRequest
    {
        public string Id { get; set; }
    }
}
