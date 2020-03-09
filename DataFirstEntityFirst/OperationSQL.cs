using System;
using System.Linq;
using DataFirstEntityFirst.Entity;

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
                students.ForEach(student => Console.WriteLine(student.Name));
            }
        }

        public static void CreateStudent(Student student)
        {
            StudentEntities db = new StudentEntities();
            db.Student.Add(student);
            db.SaveChangesAsync();
            Console.WriteLine("Create Successfully");
        }

        public static void UpdateStudent(int id, string Name)
        {
            using (StudentEntities db = new StudentEntities())
            {
                var students = db.Student.Where(student => student.Studentid == id).ToList();
                students.ForEach(student => student.Name = Name);
                db.SaveChangesAsync();
                Console.WriteLine("Update successfully");
            }
        }

        public static void DeleteStudent(int id)
        {
            using (StudentEntities db = new StudentEntities())
            {
                var students = db.Student.Where(student => student.Studentid == id).ToList();
                db.Student.RemoveRange(students);
                db.SaveChangesAsync();
                Console.WriteLine("Delete successfully");
            }
        }


    }
}
