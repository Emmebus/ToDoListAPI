namespace ToDoListAPI.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public int ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }

        public Models.Task CreateTask(string description, int ToDoListId)
        {
            Task newTask = new Task();

            newTask.Description= description;
            newTask.ToDoListId = ToDoListId;

            return newTask;
        }

        public Task SetUpdatedFields(Task task, string? description, bool? completed, int? toDoListId)
        {
            task.Description = description ?? task.Description;
            task.IsCompleted = completed ?? task.IsCompleted;
            task.ToDoListId = toDoListId ?? task.ToDoListId;

            return task;
        }

    }
}
