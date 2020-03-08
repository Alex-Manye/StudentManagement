using System;
using System.Linq;
namespace DatabaseFirstEntityFramework.Entity
{
    public class OperationSql
    {
        public static void ReadStudents()
        {
            using (StudentEntities db = new StudentEntities())
            {
                var students = (from student in db.Student
                                select student).ToList();
                students.ForEach(student => Console.WriteLine(student.StudentName));
            }
        }

        public static void CreateStudent(string Name, string LastName, DateTime Birthday)
        {
            StudentEntities db = new StudentEntities();
            Student student = new Student
            {
                StudentName = Name,
                StudentLastName = LastName,
                BirthDate = Birthday
            };
            db.Student.Add(student);
            db.SaveChangesAsync();
            Console.WriteLine("Create Successfully");
        }

        public static void UpdateStudent(int id,string Name)
        {
            using (StudentEntities db = new StudentEntities())
            {
                var students = db.Student.Where(student => student.StudentId == id).ToList();
                students.ForEach(student => student.StudentName = Name);
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
