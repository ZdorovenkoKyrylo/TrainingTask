using Microsoft.EntityFrameworkCore;
using task.Data;
using task.DTO;
using task.Models;
using task.Repositories;

namespace task.Services
{
    public class TeacherService 
    {
        private readonly IRepository<Teacher> repository;
        public TeacherService(IRepository<Teacher> repository)
        {
            this.repository = repository;
        }
        public bool Update(TeacherDto teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            var entity = new Teacher
            {
                Id = teacher.Id,
                Name = teacher.Name
            };
            return repository.Update(entity);
        }
        public void Add(TeacherDto teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            var entity = new Teacher
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Position = teacher.Position
            };
            repository.Add(entity);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
        public TeacherDtoOutput Retrieve(int id)
        {
            var teacher = repository.Retrieve(id);
            if (teacher == null)
                throw new ArgumentNullException(nameof(teacher));
            return new TeacherDtoOutput
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Position = teacher.Position,
                Courses = teacher.Courses.Select(c => c.Name).ToList()
            };
        }
        public IEnumerable<TeacherDtoOutput>? RetrieveAll()
        {
            var teacher = repository.RetrieveAll();
            return teacher.Select(teacher => new TeacherDtoOutput
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Position = teacher.Position,
                Courses = teacher.Courses.Select(c => c.Name).ToList()
            });
        }
    }
}
