using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete
{
	public class CartManager:ICartService
	{
        private readonly ICartDal _cartDal;

        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }

        public Cart GetByOwner(int ownerId)
        {
          return  _cartDal.GetByOwner(ownerId);
        }

        public void RemoveFromCart(int id, int userId)
        {
            _cartDal.RemoveFromCart(id, userId);
        }

        public void TDelete(Cart t)
        {
            throw new NotImplementedException();
        }

        public Cart TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cart> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Cart t)
        {
            _cartDal.Insert(t);
        }

        public void TUpdate(Cart t)
        {
            throw new NotImplementedException();
        }
    }
}

