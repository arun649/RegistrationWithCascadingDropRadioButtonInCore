using Microsoft.AspNetCore.Mvc.Rendering;

namespace RegistrationnApplication.ViewModel
{
    public class StateVm
    {
        public int StateId { get; set; }
        public string? Name { get; set; }
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> GetCountryList {  get; set; }
    }
}
