using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Abstractions.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        string Unhash(string hashedPassword);
    }
}
