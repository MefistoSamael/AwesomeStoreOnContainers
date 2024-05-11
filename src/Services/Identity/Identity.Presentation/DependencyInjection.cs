using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Models;
using Identity.Infrastracture.Authentication;
using Identity.Infrastracture.Data;
using Identity.Infrastracture.Implementations;
using Identity.Presentation.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Identity.Presentation
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
        {          
           

            return services;
        }
    }
}
