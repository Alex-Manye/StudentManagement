using System.Data.Entity;
namespace CodeFirstEntityFramework
{
    class StudentContext : DbContext
    {
        public StudentContext() : base("vueling-Students")
        {
            Database.SetInitializer<StudentContext>(new CreateDatabaseIfNotExists<StudentContext>());
        }

        public DbSet<StudentDao> Students { get; set; }

    }

}
