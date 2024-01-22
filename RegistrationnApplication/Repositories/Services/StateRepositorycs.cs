using Microsoft.EntityFrameworkCore;
using RegistrationnApplication.Data;
using RegistrationnApplication.Models;
using RegistrationnApplication.Repositories.Interface;

namespace RegistrationnApplication.Repositories.Services
{
    public class StateRepositorycs : IStateRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StateRepositorycs(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateState(State state)
        {
            _dbContext.states.Add(state);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteState(int id)
        {
            var record = await _dbContext.states.FindAsync(id);
            if(record != null)
            {
                _dbContext.states.Remove(record);
               await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<State> GetStateById(int id)
        {
            return await _dbContext.states.FindAsync(id);
        }

        public async Task<IEnumerable<State>> GetStatesByCountryId(int countryId)
        {
            return await _dbContext.states.Where(x=>x.CountryId ==countryId).ToListAsync();
        }

        public  async Task UpdateState(State state)
        {
            _dbContext.Update(state);
            await _dbContext.SaveChangesAsync();    
        }
       
        public async Task<IEnumerable<State>> GetAllStates()
        {
            var query = from state in _dbContext.states
                        join country in _dbContext.countries on state.CountryId equals country.CountryId into countryGroup
                        from country in countryGroup.DefaultIfEmpty()
                        orderby state.StateId
                        select new State
                        {
                            StateId = state.StateId,
                            CountryId = state.CountryId,
                            Name = state.Name,
                            Country = new Country { CountryId = country.CountryId, Name = country.Name }
                        };

            return await query.ToListAsync();
        }

    }
}
