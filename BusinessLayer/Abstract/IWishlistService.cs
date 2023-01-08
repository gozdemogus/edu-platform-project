using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Abstract
{
	public interface IWishlistService : IGenericService<Wishlist>
    {
        public Wishlist FindByUser(int userId);

    }
}

