using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 5;
            string Name = "Ariadna";
            string LastName = "Gimenez";
            DateTime Birthday = new DateTime(2002, 02, 17);
            OperationSQL.ReadStudents();
            //OperationSQL.UpdateStudent(id,Name);
            //OperationSql.DeleteStudent(id);
            //OperationSQL.CreateStudent(Name, LastName, Birthday);
            Console.ReadLine();
        }
    }
}
