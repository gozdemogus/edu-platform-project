using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface IAccountDal:IGenericUOWDal<Account>
	{

        public Account GetByAppUserId(int id);


    }
}

