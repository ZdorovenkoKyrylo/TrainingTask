namespace task.DTO
{
    public class TeacherDto
    {      
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public List<CourseDto>? Courses { get; set; }
    }
}
