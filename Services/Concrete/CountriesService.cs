using Microsoft.EntityFrameworkCore;
using RaquunProject.DataAccess;
using RaquunProject.DataAccess.Entities;
using RaquunProject.DataAccess.Result;
using RaquunProject.DTOs;
using RaquunProject.Services.Abstract;

namespace RaquunProject.Services.Concrete
{
    public class CountriesService : ICountriesService
    {
        #region Fields
        private readonly RaquunProjectDbContext _context;
        #endregion

        #region Ctor
        public CountriesService(RaquunProjectDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<Result<Country>> Add(AddUpdateCountryDTO country)
        {
            try
            {
                if (country == null || _context.Countries == null)
                    return new Result<Country> { Success = false, Message = "Current country is null. Please try again!" };

                var model = new Country
                {
                    Name = country.Name,
                    Description = country.Description,
                    PhoneCode = country.PhoneCode,
                    Capital = country.Capital,
                    Population = country.Population,
                    Surface = country.Surface
                };

                _context.Countries.Add(model);
                await _context.SaveChangesAsync();
                return new Result<Country> { Success = true, Data = model, Message = "The country named " + country.Name + " is added successfully." };
            }
            catch (Exception ex)
            {
                return new Result<Country> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result<Country>> Update(int id, AddUpdateCountryDTO updatedCountry)
        {
            try
            {
                if (_context.Countries == null)
                    return new Result<Country> { Success = false, Message = "Selected country was not found!" };

                var country = await _context.Countries.FindAsync(id);

                if (country == null)
                    return new Result<Country> { Success = false, Message = "Selected country was not found!" };

                country.Name = updatedCountry.Name;
                country.Description = updatedCountry.Description; 
                country.Population = updatedCountry.Population;
                country.Capital = updatedCountry.Capital;
                country.Surface = updatedCountry.Surface;
                country.PhoneCode = updatedCountry.PhoneCode;

                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return new Result<Country> { Success = true, Data = country, Message = country.Name + " was updated successfully!" };
            }
            catch (Exception ex)
            {
                return new Result<Country> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result<Country>> Delete(int id)
        {
            try
            {
                if (_context.Countries == null)
                    return new Result<Country> { Success = false, Message = "Selected country was not found!" };

                var country = await _context.Countries.FindAsync(id);

                if (country == null)
                    return new Result<Country> { Success = false, Message = "Selected country was not found!" };

                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
                return new Result<Country> { Success = true, Message = "Country has been deleted successfully!" };
            }
            catch (Exception ex)
            {
                return new Result<Country> { Success = false, Message = ex.Message };
            }
        }

        public async Task<Result<Country>> GetCountry(int id)
        {
            if (_context.Countries == null)
                return new Result<Country> { Success = false, Message = "Selected country was not found!" };
            
            var city = await _context.Countries.Include(x => x.Cities).FirstOrDefaultAsync(x => x.Id == id);
            
            if (city == null)
                return new Result<Country> { Success = false, Message = "Selected country was not found!" };
            
            return new Result<Country> { Success = true, Data = city };
        }

        public async Task<List<Country>> GetCountries()
        {
            if (_context.Countries == null)
                return new List<Country>();

            return await _context.Countries.Include(x => x.Cities).ToListAsync();
        }
        #endregion
    }
}
