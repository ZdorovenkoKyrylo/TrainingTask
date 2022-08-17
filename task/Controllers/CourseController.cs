using Microsoft.AspNetCore.Mvc;
using task.DTO;
using task.Repositories;
using task.Services;

namespace task.Controllers
{
    [ApiController]
    [Route("courses")]
    public class CourseController:Controller
    {
        private readonly ICourse repository;
        public CourseController(ICourse repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] CourseDto course)
        {
            repository.Add(course);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult Retrieve([FromRoute] int id)
        {
            var course = repository.Retrieve(id);
            if (course is null)
            {
                return NotFound();
            }
            return Ok(course);
        }
        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> RetrieveAll()
        {
            var courses = repository.RetrieveAll();

            return Ok(courses.ToList());
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CourseDto newCourse)
        {
            var result = repository.Update(newCourse);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = repository.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
