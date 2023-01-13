using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete
{
	public class TodoItemManager:ITodoItemService
	{
        private readonly ITodoItemDal _todoItemDal;

        public TodoItemManager(ITodoItemDal todoItemDal)
        {
            _todoItemDal = todoItemDal;
        }

        public void TDelete(TodoItem t)
        {
            _todoItemDal.Delete(t);
        }

        public TodoItem TGetById(int id)
        {
            return _todoItemDal.GetById(id);
        }

        public List<TodoItem> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(TodoItem t)
        {
            _todoItemDal.Insert(t);
        }

        public void TUpdate(TodoItem t)
        {
            _todoItemDal.Update(t);
        }
    }
}

