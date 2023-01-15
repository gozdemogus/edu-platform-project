using System;
using BaseIdentity.BusinessLayer.Abstract.AbstractUOW;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.UnitOfWork;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete.ConcreteUOW
{
	public class AccountManager:IAccountService
	{
        private readonly IAccountDal _accountDal;
        private readonly IUOWDal _iUOWDal;

        public AccountManager(IAccountDal accountDal, IUOWDal iUOWDal)
        {
            _accountDal = accountDal;
            _iUOWDal = iUOWDal;
        }

        public Account TGetByID(int id)
        {
           return _accountDal.GetByID(id);
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _iUOWDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _iUOWDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _iUOWDal.Save();
        }
    }
}

