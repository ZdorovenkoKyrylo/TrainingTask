namespace task.DTO
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public GroupDto? Group { get; set; } = null;
        public int? GroupId { get; set; } = null;
    }
}
