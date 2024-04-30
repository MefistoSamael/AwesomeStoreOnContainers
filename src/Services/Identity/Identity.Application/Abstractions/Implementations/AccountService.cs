using Identity.Application.Abstractions.Interfaces;
using Identity.Domain.Abstractions.Interfaces;
using Identity.Domain.Models;

namespace Identity.Application.Abstractions.Implementations
{
    public class LoginService : IloginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginService(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> LoginAsync(string username, string password, string email)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmail(username);

            if (user is null || user.PasswordHash != password)
                throw new Exception("handle me");

            string token = await _jwtProvider.Generate(user);

            return token;
        }

        public Task<string> RefreshTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
