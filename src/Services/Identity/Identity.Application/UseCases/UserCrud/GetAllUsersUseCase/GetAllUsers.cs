using Identity.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.UserCrud.GetAllUsersUseCase
{
    public class GetAllUsers : IRequest<IEnumerable<ApplicationUser>>
    {
    }
}
