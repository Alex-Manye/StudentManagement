using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeFirstEntityFramework.Tests
{
    [TestClass()]
    public class OperationSQLTests
    {
        [TestMethod()]
        public void ReadStudentTest()
        {
            OperationSQL.ReadStudents();
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

            OperationSQL.CreateStudent(student);
        }

        [TestMethod()]
        public void UpdateStudentTest()
        {
            string name = "Marta";
            OperationSQL.UpdateStudent(1,name);

        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            OperationSQL.DeleteStudent(1);
        }
    }
}