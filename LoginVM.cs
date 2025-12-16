using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
