using Microsoft.EntityFrameworkCore;
using task.Data;
using task.DTO;
using task.Models;

namespace task.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly SchoolContext context;
        public TeacherRepository(SchoolContext context)
        {
            this.context = context;
        }
        public void Add(Teacher entity)
        {
            var teacher = new Teacher
            {
                Name = entity.Name,
                Position = entity.Position,
            };
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var teacher = context.Teachers.FirstOrDefault(teacher => teacher.Id == id);
            if (teacher is null)
            {
                return false;
            }
            context.Teachers.Remove(teacher);
            context.SaveChanges();
            return true;           
        }

        public Teacher? Retrieve(int id)
        {
            return context.Teachers.Include(teacher => teacher.Courses).FirstOrDefault(teacher => teacher.Id == id);
        }

        public IEnumerable<Teacher> RetrieveAll()
        {
            return context.Teachers.Include(teacher => teacher.Courses).ToList();
        }

        public bool Update(Teacher entity)
        {
            var teacher = context.Teachers.FirstOrDefault(teacher => teacher.Id == entity.Id);
            if (teacher is null)
            {
                return false;
            }
            teacher.Name = entity.Name;
            teacher.Position = entity.Position;
            context.Teachers.Update(teacher);
            context.SaveChanges();
            return true;
        }
    }
}
