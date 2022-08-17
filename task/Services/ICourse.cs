using task.DTO;

namespace task.Services
{
    public interface ICourse
    {
        void Add(CourseDto entity);
        bool Delete(int id);
        bool Update(CourseDto entity);
        CourseDtoOutput? Retrieve(int id);
        IEnumerable<CourseDtoOutput> RetrieveAll();
    }
}
