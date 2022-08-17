using Microsoft.EntityFrameworkCore;
using task.Data;
using task.DTO;
using task.Models;

namespace task.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly SchoolContext context;
        public CourseRepository(SchoolContext context)
        {
            this.context = context;
        }
        public void Add(Course entity)
        {
            context.Courses.Add(entity);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var course = context.Courses.FirstOrDefault(course => course.Id == id);
            if (course is null)
            {
                return false;
            }
            context.Courses.Remove(course);
            context.SaveChanges();
            return true;
        }

        public Course? Retrieve(int id)
        {
            return context.Courses.Include(course => course.Teacher).Include(course => course.Groups).FirstOrDefault(course => course.Id == id);
        }
        
        public IEnumerable<Course> RetrieveAll()
        {
            return context.Courses.Include(course => course.Teacher).Include(course => course.Groups).ToList();
        }

        public bool Update(Course entity)
        {
            var course = context.Courses.FirstOrDefault(course => course.Id == entity.Id);
            if (course is null)
            {
                return false;
            }
            course.Name = entity.Name;
            context.Courses.Update(course);
            context.SaveChanges();
            return true;
        }
    }
}
