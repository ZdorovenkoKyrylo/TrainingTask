using task.DTO;
using task.Models;
using task.Repositories;

namespace task.Services
{
    public class CourseService:ICourse
    {
        private readonly IRepository<Course> repository;
        public CourseService(IRepository<Course> repository)
        {
            this.repository = repository;
        }
        public bool Update(CourseDto course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            var entity = new Course
            {
                Id = course.Id,
                Name = course.Name
            };
            return repository.Update(entity);
        }
        public void Add(CourseDto course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            var entity = new Course
            {
                Id = course.Id,
                Name = course.Name,
                TeacherId = course.Teacher.Id,               

            };
            repository.Add(entity);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
        public CourseDtoOutput? Retrieve(int id)
        {
            var course = repository.Retrieve(id);
            if (course == null)
                throw new ArgumentNullException(nameof(course));
            return new CourseDtoOutput
            {
               Id = course.Id,
               Name = course.Name,
               Teacher = course.Teacher.Name,
               Groups = course.Groups.Select(g => g.Name).ToList()
            };
        }
        public IEnumerable<CourseDtoOutput>? RetrieveAll()
        {
            var course = repository.RetrieveAll();
            return course.Select(c => new CourseDtoOutput
            {
                Id = c.Id,
                Name = c.Name,
                Teacher = c.Teacher.Name,
                Groups = c.Groups.Select(group => group.Name).ToList()
            }); 
        }
    }
}
