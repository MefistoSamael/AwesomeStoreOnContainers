using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Services;
public interface IUserService
{
    public Task<bool> IsExistsUserAsync(string userId);
}
