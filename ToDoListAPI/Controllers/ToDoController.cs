using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using ToDoListAPI.Services.ToDoListService;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;
        public ToDoController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpPost("/AddToDoList/{title}")]
        public async Task<ActionResult<ServiceResponse<ToDoList>>> AddToDoList(string title) 
        {
            var response = await _toDoListService.AddToDoList(title);
            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost("/AddTask/{description}/{toDoListId:int}")]
        public async Task<ActionResult<ServiceResponse<Models.Task>>> AddTask(string description, int toDoListId)
        {
            var response = await _toDoListService.AddTask(description, toDoListId);
            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("/GetToDoLists/{id:int}")]
        public async Task<ActionResult<ServiceResponse<ToDoList>>> GetToDoLists(int id)
        {
            var response = await _toDoListService.GetToDoListById(id);
            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet("/GetAllToDoLists")]
        public async Task<ActionResult<ServiceResponse<List<ToDoList>>>> GetAllToDoLists()
        {
            var response = await _toDoListService.GetAllToDoLists();
            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut("/UpdateToDoLists/{id:int}/{newTitle}")]
        public async Task<ActionResult<ServiceResponse<ToDoList>>> UpdateToDoList(int id, string newTitle)
        {
            var response = await _toDoListService.UpdateToDoList(id, newTitle);
            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut("/UpdateTask/{id}")]
        public async Task<ActionResult<ServiceResponse<Models.Task>>> UpdateTask(int id, string? newDescription, bool? completed, int? toDoListId)
        {
            var response = await _toDoListService.UpdateTask(id, newDescription, completed, toDoListId);
            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("/DeleteToDoLists/{id:int}")]
        public async Task<ActionResult<ServiceResponse<ToDoList>>> DeleteToDoList(int id)
        {
            var response = await _toDoListService.DeleteToDoList(id);
            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("/DeleteTask/{id:int}")]
        public async Task<ActionResult<ServiceResponse<Models.Task>>> DeleteTask(int id)
        {
            var response = await _toDoListService.DeleteTask(id);
            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}