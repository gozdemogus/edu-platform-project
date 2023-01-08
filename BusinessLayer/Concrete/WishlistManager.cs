using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete
{
	public class WishlistManager:IWishlistService
	{
        private readonly IWishlistDal _wishlistDal;

        public WishlistManager(IWishlistDal wishlistDal)
        {
            _wishlistDal = wishlistDal;
        }

        public Wishlist FindByUser(int userId)
        {
            return _wishlistDal.FindByUser(userId);
        }

        public void TDelete(Wishlist t)
        {
            throw new NotImplementedException();
        }

        public Wishlist TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Wishlist> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Wishlist t)
        {
            _wishlistDal.Insert(t);
        }

        public void TUpdate(Wishlist t)
        {
            throw new NotImplementedException();
        }
    }
}

