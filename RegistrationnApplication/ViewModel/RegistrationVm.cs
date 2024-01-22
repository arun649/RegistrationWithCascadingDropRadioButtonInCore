using Microsoft.AspNetCore.Mvc.Rendering;

namespace RegistrationnApplication.ViewModel
{
    public class RegistrationVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        public int CountryId { get; set; }

        public int StateId { get; set; }
        public IEnumerable<SelectListItem> SelectStateLists { get; set; }
    }
}
