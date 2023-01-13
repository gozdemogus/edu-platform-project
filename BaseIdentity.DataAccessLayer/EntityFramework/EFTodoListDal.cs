using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
	public class EFTodoListDal : GenericRepository<TodoList>, ITodoListDal
    {
        public TodoList getTodoListByUser(int userId)
        {
            using (var context = new Context())
            {
                var values = context.TodoLists
                    .Include(c => c.TodoItems)
                 .Where(x => x.UserId == userId).FirstOrDefault();
                return values;

            }
        }
    }
}

