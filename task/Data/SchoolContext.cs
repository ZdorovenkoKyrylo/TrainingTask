using Microsoft.EntityFrameworkCore;
using task.Models;

namespace task.Data
{
    public class SchoolContext:DbContext
    {
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
    }
}
