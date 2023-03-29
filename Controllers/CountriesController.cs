using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaquunProject.DataAccess;
using RaquunProject.DataAccess.Entities;
using RaquunProject.DataAccess.Result;
using RaquunProject.DTOs;
using RaquunProject.Services.Abstract;

namespace RaquunProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpPost]
        public async Task<Result<Country>> AddCountry(AddUpdateCountryDTO country)
        {
            var result = await _countriesService.Add(country);
            return new Result<Country> { Success = result.Success, Data = result.Data, Message = result.Message };
        }

        [HttpPut("{id}")]
        public async Task<Result<Country>> UpdateCountry(int id, AddUpdateCountryDTO updatedCountry)
        {
            var result = await _countriesService.Update(id, updatedCountry);
            return new Result<Country> { Success = result.Success, Data = result.Data, Message = result.Message };
        }

        [HttpDelete("{id}")]
        public async Task<Result<Country>> DeleteCountry(int id)
        {
            var result = await _countriesService.Delete(id);
            return new Result<Country> { Success = result.Success, Data = result.Data, Message = result.Message };
        }

        [HttpGet("{id}")]
        public async Task<Result<Country>> GetCountry(int id)
        {
            var result = await _countriesService.GetCountry(id);
            return new Result<Country> { Success = result.Success, Data = result.Data, Message = result.Message };
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _countriesService.GetCountries();
        }
    }
}
