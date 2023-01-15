using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Repository
{
	public class GenericUOWRepository<T>:IGenericUOWDal<T> where T:class
	{
        private readonly Context _context;

        public GenericUOWRepository(Context context)
        {
            _context = context;
        }

        public void Update(T t)
        {
            _context.Update(t);
        }

        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void MultiUpdate(List<T> t)
        {
            //birden fazla update
            _context.UpdateRange(t);
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}

