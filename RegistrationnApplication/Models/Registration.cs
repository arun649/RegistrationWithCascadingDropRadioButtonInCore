using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationnApplication.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        [ForeignKey("State")]
        public int? StateId { get; set; }  // Make StateId nullable
        public virtual State? State { get; set; }
    }

}
