using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationnApplication.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string? Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId {  get; set; }
        public Country? Country { get; set; }

    }
}
