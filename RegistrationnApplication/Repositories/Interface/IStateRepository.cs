using RegistrationnApplication.Models;

namespace RegistrationnApplication.Repositories.Interface
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetStatesByCountryId(int countryId);
        Task<State> GetStateById(int id);
        Task CreateState(State state);
        Task UpdateState(State state);
        Task DeleteState(int id);
        Task<IEnumerable<State>> GetAllStates();
    }
}
