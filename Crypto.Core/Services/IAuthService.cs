using Crypto.Core.DTOs;
using Crypto.Data.Models;

namespace Crypto.Core.Services
{
    public interface IAuthService
    {
        UserDto GetUserId(Guid Id);
        AuthenticatedResponse Login(string Username, string Password);
        Task<User> Register(CreateUserDto user);
    }

}
