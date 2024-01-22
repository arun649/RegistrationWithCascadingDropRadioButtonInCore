using RegistrationnApplication.Models;

namespace RegistrationnApplication.Repositories.Interface
{
    public interface ICountryRepositroy
    {
        Task<IEnumerable<Country>> GetAllCountryList();
        Task<Country> GetCountryById(int id);
        Task CreateCountry(Country country);
        Task UpdateCountry(Country country);
        Task DeleteCountry(int id);
    }
}
