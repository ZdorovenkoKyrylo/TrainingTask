namespace task.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Student>? Students { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
