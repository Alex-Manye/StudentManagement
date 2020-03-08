using System;
using DatabaseFirstEntityFramework.Entity;

namespace DatabaseFirstEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 200;
            string Name = "Paula";
            string LastName = "Gimenez";
            DateTime Birthday = new DateTime(2002, 02, 17);
            //OperationSql.ReadStudents();
            //OperationSql.UpdateStudents(id);
            //OperationSql.DeleteStudent(id);
            OperationSql.CreateStudent(Name,LastName, Birthday);
            Console.ReadLine();

        }
    }
}
