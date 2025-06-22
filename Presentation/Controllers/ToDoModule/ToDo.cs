using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.ServicesInterfaces.ToDoModule;
using Shared.DTOs.ToDoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers.ToDoModule
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ToDo(IToDoService _toDoService) : ControllerBase
    {
        [HttpPost]
        public ActionResult AddToDo(NewToDoDto newToDoDto)
        {
            _toDoService.Add(newToDoDto);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteToDo(Guid id)
        {
            _toDoService.Remove(id);
            return Ok();
        }

        [HttpGet("GetToDos")]
        public ActionResult GetAllTodo()
        {
            var todoList = _toDoService.GetAll();
            return Ok(todoList);
        }

        [HttpPut]
        public ActionResult UpdateTodo(Guid id, UpdatedToDoDto updatedToDoDto)
        {
            _toDoService.Update(id, updatedToDoDto);
            return Ok();
        }
    }
}
