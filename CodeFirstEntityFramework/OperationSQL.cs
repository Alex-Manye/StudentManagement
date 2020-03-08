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

       

    }
}