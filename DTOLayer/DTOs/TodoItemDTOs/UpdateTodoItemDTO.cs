using System;
using BaseIdentity.EntityLayer.Concrete;

namespace DTOLayer.DTOs.TodoItemDTOs
{
	public class UpdateTodoItemDTO
	{
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Details { get; set; }
    }
}

