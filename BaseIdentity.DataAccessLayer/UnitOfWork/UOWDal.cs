using System;
using BaseIdentity.DataAccessLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.UnitOfWork
{
    public class UOWDal : IUOWDal
    {
        //contextleri base bir contextten miras alıp sonrasında entity frameworkte eslestirmis olacagız
        private readonly Context _context;

        public UOWDal(Context context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

