using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaquunProject.DataAccess.DTOs;
using RaquunProject.DataAccess.Entities;
using RaquunProject.DataAccess.Result;
using RaquunProject.Services.Abstract;

namespace RaquunProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }   

        [HttpPost]
        public async Task<Result<City>> AddCity(AddUpdateCityDTO city)
        {
            var result = await _citiesService.Add(city);
            return new Result<City> { Success = result.Success, Data = result.Data, Message = result.Message };
        }

        [HttpPut("{id}")]
        public async Task<Result<City>> UpdateCity(int id, AddUpdateCityDTO updatedCity)
        {
            var result = await _citiesService.Update(id, updatedCity);
            return new Result<City> { Success = result.Success, Data = result.Data, Message = result.Message };
        }

        [HttpDelete("{id}")]
        public async Task<Result<City>> DeleteCity(int id)
        {
            var result = await _citiesService.Delete(id);
            return new Result<City> { Success = result.Success, Data = result.Data, Message = result.Message };
        }

        [HttpGet("{id}")]
        public async Task<Result<City>> GetCity(int id)
        {
            var result = await _citiesService.GetCity(id);
            return new Result<City> { Success = result.Success, Data = result.Data, Message = result.Message };
        }

        [HttpGet]
        public async Task<IEnumerable<City>> GetCities()
        {
            return await _citiesService.GetCities();
        }
    }
}
