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
        public ActionResult<IEnumerable<TaskModel>> Get()
        {
            return _todoService.TaskModel;
        }

        [HttpPut("{Id}")]
        public ActionResult Update([FromBody] TaskModel taskItem)
        {
            _todoService.Update(Id, taskItem);
            return XXXX;
        }

        [HttpPost]
        public ActionResult Create([FromBody] TaskModel taskItem)
        {
            _todoService.Create(taskItem);
            return XXXX;
        }

        [HttpDelete("{Id}")]
        public ActionResult Delete(long Id)
        {
            _todoService.Delete(Id);
            return XXXX;

        }

    }
}   