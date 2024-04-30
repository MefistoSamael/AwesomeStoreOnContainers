namespace Identity.Application.Abstractions.Interfaces
{
    public interface IAccountService
    {
        public Task<string> LoginAsync(string username, string password, string email);

        public Task<string> RefreshTokenAsync(string token);

        public Task<string> RegisterAsync(string username, string password, string email);
    }
}
