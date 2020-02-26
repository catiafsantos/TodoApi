using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/todo")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IEnumerable<TaskModel> Get()
        {
            return _todoService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<TaskModel> Get(long id)
        {
            return _todoService.Get(id);
        }

        [HttpPut("{id}")]
        public ActionResult Update(long id, [FromBody] TaskModel taskItem)
        {
            _todoService.Update(id, taskItem);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Create([FromBody] TaskModel taskItem)
        {
            var result = _todoService.Create(taskItem);
            return Created($"{Request.Path}/{result}",result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _todoService.Delete(id);
            return NoContent();

        }

    }
}   