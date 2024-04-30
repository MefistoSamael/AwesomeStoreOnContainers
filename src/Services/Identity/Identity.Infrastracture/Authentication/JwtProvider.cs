using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Infrastracture.Authentication
{
    internal class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        private readonly IRoleRepository _roleRepository;

        public JwtProvider(IOptions<JwtOptions> options, IRoleRepository roleRepository)
        {
            _options = options.Value;
            _roleRepository = roleRepository;
        }

        public async Task<string> Generate(ApplicationUser user)
        {
            var role = (await _roleRepository.GetUserRolesAsync(user.Id)).Single();

            var claims = new Claim[] 
            {
                new (JwtRegisteredClaimNames.Sub, user.Id),
                new (JwtRegisteredClaimNames.Email, user.Email),
                new ("role", role.Name),

            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SecretKey)), 
                SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _options.Issuer, 
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1));

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
