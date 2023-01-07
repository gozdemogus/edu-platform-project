using System;
using BaseIdentity.DataAccessLayer.Abstract;
using BaseIdentity.DataAccessLayer.Concrete;
using BaseIdentity.DataAccessLayer.Repository;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseIdentity.DataAccessLayer.EntityFramework
{
	public class EFCartDal : GenericRepository<Cart>, ICartDal
    {
        public EFCartDal()
        {
        }

        public void RemoveFromCart(int id, int userId)
        {
            using (var context = new Context())
            {
                var course =  context.Carts
                  .Where(c => c.AppUserId == userId)
                  .SelectMany(c => c.CartCourses)
                  .Include(cc => cc.Course.Instructor)
                  .Where(cc => cc.Course.Id == id)
                  .Select(cc => cc.Course)
                  .FirstOrDefault();

                var courseId = course.Id;

                var cart =  context.Carts
                  .Where(c => c.AppUserId == userId)
                  .SelectMany(c => c.CartCourses)
                  .Where(cc => cc.CourseId == courseId)
                  .FirstOrDefault();

                context.CartCourses.Remove(cart);

                 context.SaveChanges();

            }
        }

        public Cart GetByOwner(int ownerId)
        {
            using (var context = new Context())
            {
              return context.Carts.Where(x => x.AppUserId == ownerId).FirstOrDefault();
            }
        }
    }
}

