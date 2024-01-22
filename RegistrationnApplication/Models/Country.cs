using System.ComponentModel.DataAnnotations;

namespace RegistrationnApplication.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string? Name { get; set; }
    }
}
