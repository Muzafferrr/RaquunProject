using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RaquunProject.DataAccess;
using RaquunProject.DataAccess.DTOs;
using RaquunProject.DataAccess.Entities;
using RaquunProject.DataAccess.Result;
using RaquunProject.Services.Abstract;
using RaquunProject.Services.Concrete;

namespace RaquunProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register(AddUpdateUserDTO user)
        {
            try
            {
                var result = await _userService.Add(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpGet("{username}/{password}")]
        public async Task<ActionResult<User>> Signin(string username, string password)
        {
            try
            {
                var model = new User
                {
                    Username = username,
                    Password = password
                };

                var user = await Authentication(model);
                if (user.Id == 0)
                    return StatusCode((int)HttpStatusCode.NotFound, "Invalid username or password!");

                user.Token = GenerateToken(model);
                user.Message = "User successfully logged in.";

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        private async Task<UserAuthenticationDTO> Authentication(User user)
        {
            if (user == null)
                return new UserAuthenticationDTO();

            var result = await _userService.GetByUsernamePassword(user.Username, user.Password);

            if (result == null || result.Data == null)
                return new UserAuthenticationDTO();

            return result.Data;
        }
        
        private string GenerateToken(User user)
        {
            if (user == null)
                return string.Empty;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
