using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
	public class EFEnrollmentDal : GenericRepository<Enrollment>, IEnrollmentDal
    {
		public EFEnrollmentDal()
		{
		}

        public List<Enrollment> GetEnrollmentByOwner(int id)
        {
            using (var context = new Context())
            {
                var values = context.Enrollments
                    .Include(c => c.Course)
                    .Include(c=>c.AppUser)
                    .Where(x => x.AppUserId == id)
                   .ToList();
                return values;
            }
        }
    }
}

