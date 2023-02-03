using System;
using BaseIdentity.BusinessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.EntityLayer.Concrete;

namespace BaseIdentity.BusinessLayer.Concrete
{
	public class CommentManager:ICommentService
	{
        private readonly ICommentDal _CommentDal;

        public CommentManager(ICommentDal CommentDal)
        {
            _CommentDal = CommentDal;
        }

        public List<Comment> FindByCourse(int courseId)
        {
            return _CommentDal.FindByCourse(courseId);
        }

        public void TDelete(Comment t)
        {
            throw new NotImplementedException();
        }

        public Comment TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TInsert(Comment t)
        {
            _CommentDal.Insert(t);
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}

