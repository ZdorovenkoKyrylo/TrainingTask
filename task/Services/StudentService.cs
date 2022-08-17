using task.DTO;
using task.Models;
using task.Repositories;

namespace task.Services
{
    public class StudentService
    {
        private readonly IRepository<Student> repository;
        public StudentService(IRepository<Student> repository)
        {
            this.repository = repository;
        }
        public bool Update(StudentDto student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            var entity = new Student
            {
                Id = student.Id,
                Name = student.Name,
                GroupId = student.GroupId
            };
            return repository.Update(entity);
        }
        public void Add(StudentDto student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            var entity = new Student
            {
                Id = student.Id,
                Name = student.Name,
                GroupId = student.GroupId
            };
            repository.Add(entity);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
        public StudentDtoOutput? Retrieve(int id)
        {
            var student = repository.Retrieve(id);
            if (student == null)
                throw new ArgumentNullException(nameof(student));
            return new StudentDtoOutput
            {
                Id = student.Id,
                Name = student.Name,
                Group = student.Group.Name
            };
        }
        public IEnumerable<StudentDtoOutput>? RetrieveAll()
        {
            var student = repository.RetrieveAll();
            return student.Select(s => new StudentDtoOutput
            {
                Id = s.Id,
                Name = s.Name,
                Group = s.Group.Name
            });
        }
    }
}
