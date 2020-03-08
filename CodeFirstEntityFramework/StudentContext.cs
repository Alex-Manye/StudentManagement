
using System.Data.Entity;


namespace CodeFirstEntityFramework
{
    class StudentContext:DbContext
    {
        public StudentContext() : base("VuelingStudents")
        {

        }

        public DbSet<StudentDao> Students { get; set; }

    }
}
