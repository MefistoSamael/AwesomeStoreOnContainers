using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.RoleCrud.GetRoleByIdUseCase
{
    public class GetRoleById : IRequest<ApplicationRole?>
    {
        public string RoleId { get; set; }
    }
}
