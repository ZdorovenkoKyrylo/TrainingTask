using Microsoft.AspNetCore.Mvc;
using task.DTO;
using task.Repositories;
using task.Services;

namespace task.Controllers
{
    [ApiController]
    [Route("groups")]
    public class GroupController:Controller
    {
        private readonly GroupService repository;
        public GroupController(GroupService repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] GroupDto group)
        {
            repository.Add(group);
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<GroupDto> Retrieve([FromRoute] int id)
        {
            var group = repository.Retrieve(id);
            if (group is null)
            {
                return NotFound();
            }
            return Ok(group);
        }
        [HttpGet]
        public ActionResult<List<GroupDto>> RetrieveAll()
        {
            var groups = repository.RetrieveAll();

            return Ok(groups.ToList());
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] GroupDto newGroup)
        {
            var result = repository.Update(newGroup);
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
