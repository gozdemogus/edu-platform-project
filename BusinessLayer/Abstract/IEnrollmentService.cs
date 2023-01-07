using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Abstract
{
	public interface IEnrollmentService : IGenericService<Enrollment>
    {

        public List<Enrollment> GetEnrollmentByOwner(int id);

    }
}

