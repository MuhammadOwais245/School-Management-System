using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!; 

        public int Age { get; set; }

        [Display(Name = "Class")]
        public int ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
