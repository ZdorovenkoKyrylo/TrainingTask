namespace task.DTO
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TeacherDto? Teacher { get; set; } = null;
        public List<GroupDto>? Groups { get; set; } = null;
    }
}
