using Microsoft.AspNetCore.Mvc;
using task.DTO;
using task.Repositories;
using task.Services;

namespace task.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController:Controller
    {
        private readonly StudentService repository;
        public StudentController(StudentService repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] StudentDto student)
        {
            repository.Add(student);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<StudentDto> Retrieve([FromRoute] int id)
        {
            var student = repository.Retrieve(id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> RetrieveAll()
        {
            var students = repository.RetrieveAll();

            return Ok(students.ToList());
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StudentDto newStudent)
        {
            newStudent.Id = id;
            var result = repository.Update(newStudent);
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
