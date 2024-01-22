using Microsoft.EntityFrameworkCore;
using RegistrationnApplication.Data;
using RegistrationnApplication.Models;
using RegistrationnApplication.Repositories.Interface;

namespace RegistrationnApplication.Repositories.Services
{
    public class CountryRepositroy : ICountryRepositroy
    {
        private readonly ApplicationDbContext _context;
        public CountryRepositroy(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateCountry(Country country)
        {
           _context.countries.Add(country);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteCountry(int id)
        {
            var country = await _context.countries.FindAsync(id); 
            if(country != null)
            {
                _context.countries.Remove(country);
                await  _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Country>> GetAllCountryList()
        {
            return  await _context.countries.ToArrayAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _context.countries.FindAsync(id);
        }

        public async Task UpdateCountry(Country country)
        {
           _context.countries.Update(country);
            await _context.SaveChangesAsync();
        }
    }
}
