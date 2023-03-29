using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaquunProject.DataAccess;
using RaquunProject.DataAccess.Entities;
using RaquunProject.DataAccess.Result;
using RaquunProject.DTOs;
using RaquunProject.Services.Abstract;

namespace RaquunProject.Services.Concrete
{
    public class CitiesService : ICitiesService
    {
        #region Fields
        private readonly RaquunProjectDbContext _context;
        #endregion

        #region Ctor
        public CitiesService(RaquunProjectDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<Result<City>> Add(AddUpdateCityDTO city)
        {
            try
            {
                if (city == null || _context.Cities == null)
                    return new Result<City> { Success = false, Message = "Current city is null. Please try again!" };

                var model = new City
                {
                    Name = city.Name,
                    Description = city.Description,
                    PhoneCode = city.PhoneCode,
                    Mayor = city.Mayor,
                    PlateCode = city.PlateCode,
                    Population = city.Population,
                    Surface = city.Surface,
                    CountryId = city.CountryId,
                };

                _context.Cities.Add(model);
                await _context.SaveChangesAsync();
                return new Result<City> { Success = true, Data = model, Message = "The city named " + city.Name + " is added successfully." };
            }
            catch (Exception ex)
            {
                return new Result<City> { Success = false, Message = ex.Message };
            }
        }
        public async Task<Result<City>> Update(int id, AddUpdateCityDTO updatedCity)
        {
            try
            {
                if (_context.Cities == null)
                    return new Result<City> { Success = false, Message = "Selected city was not found!" };

                var city = await _context.Cities.FindAsync(id);

                if (city == null)
                {
                    return new Result<City> { Success = false, Message = "Selected city was not found!" };
                }

                city.Name = updatedCity.Name;
                city.Description = updatedCity.Description;
                city.PhoneCode = updatedCity.PhoneCode;
                city.Population = updatedCity.Population;
                city.Surface = updatedCity.Surface;
                city.Mayor = updatedCity.Mayor;
                city.PlateCode = updatedCity.PlateCode;
                city.CountryId = updatedCity.CountryId;

                _context.Cities.Update(city);
                await _context.SaveChangesAsync();
                return new Result<City> { Success = true, Data = city, Message = updatedCity.Name + " was updated successfully!" };
            }
            catch (Exception ex)
            {
                return new Result<City> { Success = false, Message = ex.Message };
            }
        }
        public async Task<Result<City>> Delete(int id)
        {
            try
            {
                if (_context.Cities == null)
                    return new Result<City> { Success = false, Message = "Selected city was not found!" };

                var city = await _context.Cities.FindAsync(id);
                if (city == null)
                {
                    return new Result<City> { Success = false, Message = "Selected city was not found!" };
                }

                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
                return new Result<City> { Success = true, Message = "City has been deleted successfully!" };
            }
            catch (Exception ex)
            {
                return new Result<City> { Success = false, Message = ex.Message };
            }
        }
        public async Task<Result<City>> GetCity(int id)
        {
            if (_context.Cities == null)
                return new Result<City> { Success = false, Message = "Selected city was not found!" };
            
            var city = await _context.Cities.Include(x => x.Country).FirstOrDefaultAsync(x => x.Id == id);

            if (city == null)
                return new Result<City> { Success = false, Message = "Selected city was not found!" };
            
            return new Result<City> { Success = true, Data = city };
        }
        public async Task<List<City>> GetCities()
        {
            if (_context.Cities == null)
                return new List<City>();

            return await _context.Cities.Include(x => x.Country).ToListAsync();
        }
        #endregion
    }
}
