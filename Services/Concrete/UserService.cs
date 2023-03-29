using Microsoft.EntityFrameworkCore;
using RaquunProject.DataAccess;
using RaquunProject.DataAccess.DTOs;
using RaquunProject.DataAccess.Entities;
using RaquunProject.DataAccess.Result;
using RaquunProject.Services.Abstract;
using System.Diagnostics.Metrics;

namespace RaquunProject.Services.Concrete
{
    public class UserService : IUserService
    {
        #region Fields
        private readonly RaquunProjectDbContext _context;
        #endregion

        #region Ctor
        public UserService(RaquunProjectDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<Result<UserAuthenticationDTO>> GetByUsernamePassword(string username, string password)
        {
            try
            {
                if (_context.Users == null)
                    return new Result<UserAuthenticationDTO> { Success = false, Message = "Current user is null. Please try again!" };

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

                if (user == null)
                    return new Result<UserAuthenticationDTO> { Success = false, Message = "Selected user was not found!" };
                
                var model = new UserAuthenticationDTO
                {
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email
                };

                return new Result<UserAuthenticationDTO> { Success = true, Data = model };

            }
            catch (Exception ex)
            {
                return new Result<UserAuthenticationDTO> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result<User>> Add(AddUpdateUserDTO user)
        {
            try
            {
                if (user == null || _context.Users == null)
                    return new Result<User> { Success = false, Message = "Current user is null. Please try again!" };

                var model = new User
                {
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password
                };

                _context.Users.Add(model);
                await _context.SaveChangesAsync();
                return new Result<User> { Success = true, Data = model, Message = "The user named " + user.Username + " is added successfully." };
            }
            catch (Exception ex)
            {
                return new Result<User> { Success = false, Message = ex.Message };
            }
        }
        #endregion
    }
}
