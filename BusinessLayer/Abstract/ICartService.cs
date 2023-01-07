using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Abstract
{
	public interface ICartService : IGenericService<Cart>
    {
        public void RemoveFromCart(int id, int userId);
        public Cart GetByOwner(int ownerId);
    }
}

