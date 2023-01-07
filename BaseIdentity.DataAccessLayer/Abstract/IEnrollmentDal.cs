using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface IEnrollmentDal : IGenericDal<Enrollment>
    {

		public List<Enrollment> GetEnrollmentByOwner(int id);

	}
}

