using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete
{
	public class TodoListManager:ITodoListService
	{
        private readonly ITodoListDal _todoListDal;

        public TodoListManager(ITodoListDal todoListDal)
        {
            _todoListDal = todoListDal;
        }

        public TodoList getTodoListByUser(int userId)
        {
          return _todoListDal.getTodoListByUser(userId);
        }

        public void TDelete(TodoList t)
        {
            throw new NotImplementedException();
        }

        public TodoList TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TodoList> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(TodoList t)
        {
            _todoListDal.Insert(t);
        }

        public void TUpdate(TodoList t)
        {
            throw new NotImplementedException();
        }
    }
}

