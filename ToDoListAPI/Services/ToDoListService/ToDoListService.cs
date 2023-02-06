using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Threading.Tasks;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services.ToDoListService
{
    public class ToDoListService : IToDoListService
    {
        private readonly ToDoContext _context;
        private readonly ToDoList _toDoList;
        private readonly Models.Task _task;

        public ToDoListService(ToDoContext context)
        {
            _context= context;
            _toDoList = new ToDoList();
            _task = new Models.Task();
        }

        public async Task<ServiceResponse<ToDoList>> AddToDoList(string title)
        {
            _context.ToDoLists.Add(_toDoList.CreateToDoList(title));
            _context.SaveChanges();

            var serviceResponse = new ServiceResponse<ToDoList>();
            serviceResponse.Data = _context
                .ToDoLists
                .ToList()
                .LastOrDefault(x => x.Title == title);
           
            return serviceResponse;
        }

        public async Task<ServiceResponse<Models.Task>> AddTask(string description, int toDoListId)
        {
            _context.Tasks.Add(_task.CreateTask(description, toDoListId));
            _context.SaveChanges();

            var serviceResponse = new ServiceResponse<Models.Task>();
            serviceResponse.Data = _context.Tasks.ToList().LastOrDefault(x => x.Description == description);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ToDoList>>> GetAllToDoLists()
        {
            var serviceResponse = new ServiceResponse<List<ToDoList>>();
            serviceResponse.Data = _context.ToDoLists.Include(x => x.Tasks).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<ToDoList>> GetToDoListById(int id)
        {
            var serviceResponse = new ServiceResponse<ToDoList>();
            serviceResponse.Data = _context
                .ToDoLists.Include(x => x.Tasks)
                .ToList()
                .FirstOrDefault(x => x.Id == id);

            if (serviceResponse.Data == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Unable to find id";
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<ToDoList>> UpdateToDoList(int id, string newTitle)
        {
            ToDoList toDoList = _context.ToDoLists
                .Include(x => x.Tasks)
                .ToList()
                .FirstOrDefault(x => x.Id == id);
            var serviceResponse = new ServiceResponse<ToDoList>();
            if (toDoList == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Unable to find id";
            }
            else
            {
                toDoList = toDoList.SetUpdatedFields(toDoList, newTitle);
                _context.ToDoLists.Update(toDoList);
                _context.SaveChanges();
            }

            serviceResponse.Data = toDoList;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Models.Task>> UpdateTask(int id, string? description, bool? completed, int? toDoListId)
        {
            Models.Task task = _context.Tasks.ToList().FirstOrDefault(x => x.Id == id);
            var serviceResponse = new ServiceResponse<Models.Task>();
            if (task == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Unable to find id";
            }
            else { 
            task = task.SetUpdatedFields(task, description, completed, toDoListId);
            _context.Tasks.Update(task);
            _context.SaveChanges();
            }

            serviceResponse.Data = task;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ToDoList>> DeleteToDoList(int id)
        {
            var toDoList = _context.ToDoLists.Include(x => x.Tasks).ToList().FirstOrDefault(x => x.Id == id);
            var serviceResponse = new ServiceResponse<ToDoList>();
            if (toDoList == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Unable to find id";
            }
            else
            {
                _context.ToDoLists.Remove(toDoList);
                _context.SaveChanges();
            }

            serviceResponse.Data = toDoList;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Models.Task>> DeleteTask(int id)
        {
            Models.Task task = _context.Tasks.ToList().FirstOrDefault(x => x.Id == id);
            var serviceResponse = new ServiceResponse<Models.Task>();
            if (task == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Unable to find id";
            }
            else
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            
            serviceResponse.Data = task;
            return serviceResponse;
        }
    }
}
