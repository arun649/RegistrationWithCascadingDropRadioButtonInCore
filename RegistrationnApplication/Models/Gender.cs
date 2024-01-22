using System.ComponentModel.DataAnnotations;

namespace RegistrationnApplication.Models
{
    public class Gender
    {

        [Key]
        public int GenderId { get; set; }
        public string? GenderName { get; set; }
    }
}
