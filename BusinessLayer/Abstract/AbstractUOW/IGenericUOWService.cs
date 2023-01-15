using System;
namespace BaseIdentity.BusinessLayer.Abstract.AbstractUOW
{
	public interface IGenericUOWService<T>
	{
        void TInsert(T t);

        void TUpdate(T t);

        void TMultiUpdate(List<T> t);

        T TGetByID(int id);

    }
}

