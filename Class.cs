using System.Collections.Generic;

namespace SchoolManagementSystem.Models
{
    public class Class
    {
        public int Id { get; set; }

        public string ClassName { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
