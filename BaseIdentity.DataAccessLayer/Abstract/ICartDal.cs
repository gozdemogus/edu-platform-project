using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface ICartDal : IGenericDal<Cart>
    {

        public void RemoveFromCart(int id, int userId);

        public Cart GetByOwner(int ownerId);

    }
}

