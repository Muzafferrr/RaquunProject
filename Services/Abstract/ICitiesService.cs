using Microsoft.AspNetCore.Mvc;
using RaquunProject.DataAccess.Entities;
using RaquunProject.DataAccess.Result;
using RaquunProject.DTOs;

namespace RaquunProject.Services.Abstract
{
    public interface ICitiesService
    {
        Task<Result<City>> Add(AddUpdateCityDTO city);
        Task<Result<City>> Update(int id, AddUpdateCityDTO updatedCity);
        Task<Result<City>> Delete(int id);
        Task<Result<City>> GetCity(int id);
        Task<List<City>> GetCities();
    }
}
