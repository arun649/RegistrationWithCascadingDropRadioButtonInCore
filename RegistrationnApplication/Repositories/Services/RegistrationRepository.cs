using Microsoft.EntityFrameworkCore;
using RegistrationnApplication.Data;
using RegistrationnApplication.Models;
using RegistrationnApplication.Repositories.Interface;

namespace RegistrationnApplication.Repositories.Services
{
    public class RegistrationRepository : IRegistrationRepositorycs
    {
        private readonly ApplicationDbContext _context;
        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateRegistartion(Registration registration)
        {
            _context.registrations.Add(registration);
             await _context.SaveChangesAsync();
        }

        public async Task DeleteRegistartion(int id)
        {
            var registration = await _context.registrations.FindAsync(id);
            if(registration != null)
            {
                _context.registrations.Remove(registration);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Registration>> GetAllRecordAsync()
        {
            var query = from registration in _context.registrations
                        join country in _context.countries on registration.CountryId equals country.CountryId into countryGroup
                        from country in countryGroup.DefaultIfEmpty()
                        join state in _context.states on registration.StateId equals state.StateId into stateGroup
                        from state in stateGroup.DefaultIfEmpty()
                        orderby registration.Id
                        select new Registration
                        {
                            Id = registration.Id,
                            Name = registration.Name,
                            Gender = registration.Gender,
                            Description = registration.Description,
                            Email = registration.Email,
                            PhoneNumber = registration.PhoneNumber,
                            CountryId = registration.CountryId,
                            StateId = registration.StateId,
                            Country = new Country { Name = country.Name },
                            State = new State { Name = state.Name }
                        };

            return await query.ToListAsync();
        }


        public async Task<Registration> GetRecordById(int id)
        {
            return await _context.registrations.FindAsync(id);
        }

        public async Task UpdateRegistartion(Registration registration)
        {
            _context.registrations.Update(registration);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Gender>> GetAllGenderAsync()
        {
            return await _context.Genders.ToListAsync();
        }
    }
}
