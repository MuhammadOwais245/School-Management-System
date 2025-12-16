using SchoolManagementSystem.Models;

public class Attendance
{
    public int Id { get; set; }

    // Foreign Key for Class
    public int ClassId { get; set; }
    public Class Class { get; set; }

    // Foreign Key for Student
    public int StudentId { get; set; }
    public Student Student { get; set; }

    // Attendance Date
    public DateTime Date { get; set; }

    // Present / Absent
    public bool IsPresent { get; set; }
}
