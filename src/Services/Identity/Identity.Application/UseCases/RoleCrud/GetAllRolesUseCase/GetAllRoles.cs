using Identity.Application.Models;
using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.RoleCrud.GetAllRolesUseCase
{
    public class GetAllRoles : IRequest<IEnumerable<RoleDTO>>
    {

    }
}
