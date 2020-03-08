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

        public static void UpdateStudent(int id)
        {
            using (StudentEntities db = new StudentEntities())
            {
                var students = db.Student.Where(student => student.StudentId == id).ToList();
                students.ForEach(student => student.StudentName = "Paula");
                db.SaveChangesAsync();
                Console.WriteLine("Update successfully");
            }
        }

        public static void DeleteStudent(int id)
        {
            using (StudentEntities db = new StudentEntities())
            {
                var students = db.Student.Where(student => student.StudentId == id).ToList();
                db.Student.RemoveRange(students);
                db.SaveChangesAsync();
                Console.WriteLine("Delete successfully");
            }
        }


    }
}
