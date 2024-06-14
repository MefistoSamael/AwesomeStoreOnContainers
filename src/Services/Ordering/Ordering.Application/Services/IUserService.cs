namespace Ordering.Application.Services;
public interface IUserService
{
    public Task<bool> IsExistsUserAsync(string userId);
}
