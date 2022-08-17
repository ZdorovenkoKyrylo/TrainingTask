using Microsoft.AspNetCore.Mvc;
using task.Data;
using task.DTO;
using task.Models;
using task.Repositories;
using task.Services;

namespace task.Controllers
{
    [ApiController]
    [Route("teachers")]
    public class TeacherController : Controller
    {
        private readonly TeacherService repository;
        public TeacherController(TeacherService repository)
        {
            this.repository = repository;     
        }
        [HttpPost]
        public IActionResult Create([FromBody] TeacherDto teacher)
        {
            repository.Add(teacher);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<TeacherDto> Retrieve([FromRoute] int id)
        {
            var teacher = repository.Retrieve(id);
            if (teacher is null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        [HttpGet]
        public ActionResult<List<TeacherDto>> RetrieveAll()
        {
            var teachers = repository.RetrieveAll();
           
            return Ok(teachers.ToList());
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] TeacherDto newTeacher)
        {
            var result = repository.Update(newTeacher);
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
