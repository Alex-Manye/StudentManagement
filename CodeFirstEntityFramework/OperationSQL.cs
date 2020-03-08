using System;
using System.Linq;


namespace CodeFirstEntityFramework
{
    class OperationSQL
    {
        public static void ReadStudents()
        {
            using (StudentContext db = new StudentContext())
            {
                var students = (from student in db.Students
                                select student).ToList();
                students.ForEach(student => Console.WriteLine(student.StudentName));
            }
        }
        public static void CreateStudent(string Name, string LastName, DateTime Birthday)
        {
            StudentContext db = new StudentContext();
            StudentDao student = new StudentDao
            {
                StudentName = Name,
                StudentLastName = LastName,
                BirthDate = Birthday
            };
            db.Students.Add(student);
            db.SaveChangesAsync();
            Console.WriteLine("Create Successfully");
        }

        public static void UpdateStudent(int id, string Name)
        {
            using (StudentContext db = new StudentContext())
            {
                var students = db.Students.Where(student => student.StudentId == id).ToList();
                students.ForEach(student => student.StudentName = Name);
                db.SaveChangesAsync();
                Console.WriteLine("Update successfully");
            }
        }


    }
}