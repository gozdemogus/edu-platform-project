using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> FindByCourse(int courseId)
        {
            using (var context = new Context())
            {
                return context.Comments.Include(x => x.AppUser).Include(x=>x.Course).Where(x=>x.CourseId == courseId).ToList();
            }
        }
    }
}

