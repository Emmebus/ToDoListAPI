
namespace ToDoListAPI.Services.ToDoListService
{
    public interface IToDoListService
    {
        Task<ServiceResponse<ToDoList>> AddToDoList(string title);
        Task<ServiceResponse<Models.Task>> AddTask(string description, int toDoListId);
        Task<ServiceResponse<List<ToDoList>>> GetAllToDoLists();
        Task<ServiceResponse<ToDoList>> GetToDoListById(int id);
        Task<ServiceResponse<ToDoList>> UpdateToDoList(int id, string newTitle);
        Task<ServiceResponse<Models.Task>> UpdateTask(int id, string? description, bool? completed, int? toDoListId);
        Task<ServiceResponse<ToDoList>> DeleteToDoList(int id);
        Task<ServiceResponse<Models.Task>> DeleteTask(int id);
    }
}