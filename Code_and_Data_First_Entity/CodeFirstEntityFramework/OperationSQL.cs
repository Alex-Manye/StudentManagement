using System;
using System.Linq;


namespace CodeFirstEntityFramework
{
    public static class OperationSQL
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

        public static void CreateStudent(StudentDao student)
        {
            StudentContext db = new StudentContext();
            db.Students.Add(student);
            db.SaveChangesAsync();
        }

        public static void UpdateStudent(int id, string Name)
        {
            using (StudentContext db = new StudentContext())
            {
                var students = db.Students.Where(student => student.StudentId == id).ToList();
                students.ForEach(student => student.StudentName = Name);
                db.SaveChangesAsync();
            }
        }


        public static void DeleteStudent(int id)
        {
            using (StudentContext db = new StudentContext())
            {
                var students = db.Students.Where(student => student.StudentId == id).ToList();
                db.Students.RemoveRange(students);
                db.SaveChangesAsync();
            }
        }


    }
}