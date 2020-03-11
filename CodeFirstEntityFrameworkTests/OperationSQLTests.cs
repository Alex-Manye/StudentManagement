using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeFirstEntityFramework.Tests
{
    [TestClass()]
    public class OperationSQLTests
    {
        readonly OperationSQL operation = new OperationSQL();
        [TestMethod()]
        public void ReadStudentTest()
        {
            operation.ReadStudents();
        }

        [TestMethod()]
        public void CreateStudentTest()
        {
            StudentDao student = new StudentDao
            {
                StudentName = "Ingrid",
                StudentLastName = "Pardo",
                BirthDate = new DateTime(2002, 02, 17)
            };

            operation.CreateStudent(student);
        }

        [TestMethod()]
        public void UpdateStudentTest()
        {
            string name = "Marta";
            operation.UpdateStudent(1,name);

        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            operation.DeleteStudent(1402);
        }
    }
}