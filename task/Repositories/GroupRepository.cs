using Microsoft.EntityFrameworkCore;
using task.Data;
using task.DTO;
using task.Models;

namespace task.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private readonly SchoolContext context;
        public GroupRepository(SchoolContext context)
        {
            this.context = context;
        }
        public void Add(Group entity)
        {
            context.Groups.Add(entity);
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var group = context.Groups.FirstOrDefault(group => group.Id == id);
            if (group is null)
            {
                return false;
            }
            context.Groups.Remove(group);
            context.SaveChanges();
            return true;
        }

        public Group? Retrieve(int id)
        {
            return context.Groups.Include(group => group.Students).Include(group => group.Courses).FirstOrDefault(group => group.Id == id);
        }

        public IEnumerable<Group> RetrieveAll()
        {
            return context.Groups.Include(group => group.Students).Include(group => group.Courses).ToList();
        }

        public bool Update(Group entity)
        {
            var group = context.Groups.FirstOrDefault(group => group.Id == entity.Id);
            if (group is null)
            {
                return false;
            }
            group.Name = entity.Name;
            context.Groups.Update(entity);
            context.SaveChanges();
            return true;
        }
    }
}
