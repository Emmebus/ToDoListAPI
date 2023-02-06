using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
    }
}



