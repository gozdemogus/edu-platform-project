using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface ITodoListDal : IGenericDal<TodoList>
    {
		public TodoList getTodoListByUser(int userId);

     
    }
}

