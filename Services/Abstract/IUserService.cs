using RaquunProject.DataAccess.Entities;
using RaquunProject.DataAccess.Result;
using RaquunProject.DTOs;

namespace RaquunProject.Services.Abstract
{
    public interface IUserService
    {
        Task<Result<User>> Add(AddUpdateUserDTO user);
        Task<Result<UserAuthenticationDTO>> GetByUsernamePassword(string username, string password);
    }
}
