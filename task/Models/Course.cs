namespace task.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public List<Group>? Groups { get; set; }
    }
}
