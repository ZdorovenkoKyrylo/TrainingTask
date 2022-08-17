namespace task.DTO
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<StudentDto>? Students { get; set; }
        public List<CourseDto>? Courses { get; set; }
    }
}
