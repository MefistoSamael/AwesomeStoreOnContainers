using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.RoleCrud.UpdateRoleUseCase
{
    public class UpdateRole : IRequest<string>
    {
        public string RoleId { get; set; }
        public string NewRoleName { get; set; }
    }
}
