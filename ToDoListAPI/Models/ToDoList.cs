using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<Task> Tasks { get; set; }


        public ToDoList CreateToDoList(string title) 
        {
            var newToDoList = new ToDoList();
            newToDoList.Title = title;

            return newToDoList;
        }

        public ToDoList SetUpdatedFields(ToDoList toDoList, string newTitle)
        {
            toDoList.Title = newTitle;

            return toDoList;
        }
    }
}
