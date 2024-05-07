using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.UserCrud.ChangeRoleUseCase
{
    public class ChangeRole : IRequest<string>
    {
        public string UserId { get; set; }

        public string RoleName { get; set; }
    }
}
