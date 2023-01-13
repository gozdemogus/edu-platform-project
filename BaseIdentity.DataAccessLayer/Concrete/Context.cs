using System;
using BaseIdentity.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BaseIdentity.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,1433;Database=Education;MultipleActiveResultSets=true;User=SA;Password=MyPass@word;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>()
           .HasOne(c => c.Category)
           .WithMany(cat => cat.Courses)
           .HasForeignKey(c => c.CategoryId);


            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(u => u.InstructedCourses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
    .HasOne(e => e.Course)
    .WithMany(c => c.Enrollments)
    .HasForeignKey(e => e.CourseId)
    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.AppUser)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cart>()
             .HasOne(c => c.AppUser)
             .WithOne(a => a.Cart)
             .HasForeignKey<Cart>(c => c.AppUserId);


            modelBuilder.Entity<Wishlist>()
          .HasOne(c => c.AppUser)
          .WithOne(a => a.Wishlist)
          .HasForeignKey<Wishlist>(c => c.AppUserId);

            modelBuilder.Entity<Comment>()
          .HasOne(c => c.AppUser)
          .WithMany(a => a.Comments)
          .HasForeignKey(c => c.AppUserId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Course)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<AppUser>()
          .HasMany(u => u.TodoLists)
          .WithOne(t => t.AppUser)
          .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<TodoList>()
                .HasMany(t => t.TodoItems)
                .WithOne(i => i.TodoList)
                .HasForeignKey(i => i.TodoListId);


        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartCourse> CartCourses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistCourse> WishlistCourses { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }



}
