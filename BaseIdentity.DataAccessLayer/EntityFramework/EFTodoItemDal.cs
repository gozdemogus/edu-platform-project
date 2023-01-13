using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
	public class EFTodoItemDal : GenericRepository<TodoItem>, ITodoItemDal
    {
		public EFTodoItemDal()
		{
		}
	}
}

