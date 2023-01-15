using System;
namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface IGenericUOWDal<T> where T:class
	{
        void Insert(T t);
     
        void Update(T t);

        void MultiUpdate(List<T> t);

        T GetByID(int id);
    }
}

