using RegistrationnApplication.Models;

namespace RegistrationnApplication.Repositories.Interface
{
    public interface IRegistrationRepositorycs
    {
        Task<IEnumerable<Registration>>GetAllRecordAsync();
        Task<Registration> GetRecordById(int id);
        Task CreateRegistartion(Registration registration);
        Task UpdateRegistartion(Registration registration);
        Task DeleteRegistartion(int id);
        Task<IEnumerable<Gender>> GetAllGenderAsync();
    }
}
