namespace task.DTO
{
    public class GroupDtoOutput
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string> Students { get; set; }
        public List<string> Courses { get; set; }
    }
}
