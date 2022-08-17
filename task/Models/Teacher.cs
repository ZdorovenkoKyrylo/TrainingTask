namespace task.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name  { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public List<Course>? Courses { get; set; }
    }
}
