namespace task.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public virtual Group Group { get; set; }
        public int? GroupId { get; set; }
    }
}
