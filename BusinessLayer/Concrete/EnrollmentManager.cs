using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete
{
	public class EnrollmentManager : IEnrollmentService
    {

        private readonly IEnrollmentDal _enrollmentDal;

        public EnrollmentManager(IEnrollmentDal enrollmentDal)
        {
            _enrollmentDal = enrollmentDal;
        }

        public List<Enrollment> GetEnrollmentByOwner(int id)
        {
          return  _enrollmentDal.GetEnrollmentByOwner(id);
        }

        public void TDelete(Enrollment t)
        {
            throw new NotImplementedException();
        }

        public Enrollment TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Enrollment> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Enrollment t)
        {
            _enrollmentDal.Insert(t);
        }

        public void TUpdate(Enrollment t)
        {
            throw new NotImplementedException();
        }
    }
}

