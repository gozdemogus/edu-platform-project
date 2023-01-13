using System;
namespace BaseIdentity.EntityLayer.Concrete
{
	public class TodoList
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; }
    }
}

