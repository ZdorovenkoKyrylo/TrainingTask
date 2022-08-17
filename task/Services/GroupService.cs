using task.DTO;
using task.Models;
using task.Repositories;

namespace task.Services
{
    public class GroupService
    {
        private readonly IRepository<Group> repository;
        public GroupService(IRepository<Group> repository)
        {
            this.repository = repository;
        }
        public bool Update(GroupDto group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            var entity = new Group
            {
                Id = group.Id,
                Name = group.Name
            };
            return repository.Update(entity);
        }
        public void Add(GroupDto group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            var entity = new Group
            {
                Id = group.Id,
                Name = group.Name,
            };
            repository.Add(entity);
        }
        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
        public GroupDtoOutput? Retrieve(int id)
        {
            var group = repository.Retrieve(id);
            if (group == null)
                throw new ArgumentNullException(nameof(group));
            return new GroupDtoOutput
            {
                Id = group.Id,
                Name = group.Name,
                Students = group.Students.Select(g => g.Name).ToList(),
                Courses = group.Courses.Select(g => g.Name).ToList()
            };
        }

        public IEnumerable<GroupDtoOutput>? RetrieveAll()
        {
            var group = repository.RetrieveAll();
            return group.Select(g => new GroupDtoOutput
            {
                Id = g.Id,
                Name = g.Name,
                Students = g.Students.Select(g => g.Name).ToList(),
                Courses = g.Courses.Select(g => g.Name).ToList()
            });
        }
    }
}
