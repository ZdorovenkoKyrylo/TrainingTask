using Microsoft.EntityFrameworkCore;
using task.Data;
using task.DTO;
using task.Models;

namespace task.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly SchoolContext context;
        public StudentRepository(SchoolContext context)
        {
            this.context = context;
        }

        public void Add(Student entity)
        {
            context.Students.Add(entity);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var student = context.Students.FirstOrDefault(student => student.Id == id);
            if (student is null)
            {
                return false;
            }
            context.Students.Remove(student);
            context.SaveChanges();
            return true;
        }

        public Student? Retrieve(int id)
        {
            return context.Students.Include(student => student.Group).FirstOrDefault(student => student.Id == id);
        }

        public IEnumerable<Student> RetrieveAll()
        {
            return context.Students.Include(student => student.Group).ToList();
        }

        public bool Update(Student entity)
        {
            var student = context.Students.FirstOrDefault(student => student.Id == entity.Id);
            if (student is null)
            {
                return false;
            }
            student.Name = entity.Name;
            student.GroupId = entity.GroupId;
            context.Students.Update(student);
            context.SaveChanges();
            return true;
        }
    }
}
