using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface IWishlistDal : IGenericDal<Wishlist>
    {
        public Wishlist FindByUser(int userId);
    }
}

