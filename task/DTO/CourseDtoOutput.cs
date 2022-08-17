namespace task.DTO
{
    public class CourseDtoOutput
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Teacher { get; set; } = null;
        public List<string> Groups { get; set; } = null;
    }
}
