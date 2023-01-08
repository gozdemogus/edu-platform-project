using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.DataAccessLayer.Abstract
{
	public interface ICommentDal : IGenericDal<Comment>
    {

		public List<Comment> FindByCourse(int courseId);

	}
}

