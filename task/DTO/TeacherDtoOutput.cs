namespace task.DTO
{
    public class TeacherDtoOutput
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public List<string> Courses { get; set; }
    }
}
