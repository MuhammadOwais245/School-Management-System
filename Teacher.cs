using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!; 

        [Required, MaxLength(100)]
        public string Subject { get; set; } = null!; 
    }
}
