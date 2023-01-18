using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
    public class EFAccountDal : GenericUOWRepository<Account>, IAccountDal
    {
        //generic repositoryde constructor döndügün icin ve onu burada miras aldıgın icin
        //burada da constructor dönmeli
        //tanımlanan contexti enjecte etmek için base(context)
        public EFAccountDal(Context context) : base(context)
        {
        }


        public Account GetByAppUserId(int id)
        {
            using (var context = new Context())
            {
                return context.Accounts.Where(x => x.AppUserId == id).FirstOrDefault();
            }
        }
    }
}

