using CodeFirst1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeFirst1.Dal
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //Что бы таблицы не назывались Students Courses и т.д.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}