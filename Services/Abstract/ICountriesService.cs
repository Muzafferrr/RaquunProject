using RaquunProject.DataAccess.DTOs;
using RaquunProject.DataAccess.Entities;
using RaquunProject.DataAccess.Result;

namespace RaquunProject.Services.Abstract
{
    public interface ICountriesService
    {
        Task<Result<Country>> Add(AddUpdateCountryDTO country);
        Task<Result<Country>> Update(int id, AddUpdateCountryDTO updatedCountry);
        Task<Result<Country>> Delete(int id);
        Task<Result<Country>> GetCountry(int id);
        Task<List<Country>> GetCountries();
    }
}
