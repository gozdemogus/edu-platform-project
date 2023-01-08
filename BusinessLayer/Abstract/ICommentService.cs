using System;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Abstract
{
	public interface ICommentService : IGenericService<Comment>
    {
        public List<Comment> FindByCourse(int courseId);

    }
}

