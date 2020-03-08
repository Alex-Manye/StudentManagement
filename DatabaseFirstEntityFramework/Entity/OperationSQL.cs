using System;
using System.Linq;
namespace DatabaseFirstEntityFramework.Entity
{
    public class OperationSql
    {
        public static void ReadStudents()
        {
            using(StudentEntities db = new StudentEntities())
            {
                var students = (from student in db.Student
                                select student).ToList();
                students.ForEach(student => Console.WriteLine(student.StudentName));
            }
        }

        public static void UpdateStudents()
        {
            using (StudentEntities db = new StudentEntities())
            {
                db.Student.Where(students => students.StudentId == 1).ToList().Select(studen => { studen.StudentName = "Ingrid"; return studen;});
            }
            }
    }
}
