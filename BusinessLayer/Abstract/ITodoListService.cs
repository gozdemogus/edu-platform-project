using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Abstract
{
	public interface ITodoListService : IGenericService<TodoList>
    {
        public TodoList getTodoListByUser(int userId);

    }
}

