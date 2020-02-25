﻿using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<ActionResult<TaskModel>> Update([FromBody] TaskModel taskItem)
        {
            var result = _todoService.Update(taskItem);
            return IActionResult;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TaskModel taskItem)
        {
                _todoService.Create(taskItem);

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            var result = _todoService.Delete(Id);
            return result.IsValid ? Ok() : (IActionResult)BadRequest(result.Message);

        }

    }
}   