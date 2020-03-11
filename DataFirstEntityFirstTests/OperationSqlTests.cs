using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataFirstEntityFirst.Entity;

namespace DatabaseFirstEntityFramework.Entity.Tests
{
    [TestClass()]
    public class OperationSqlTests
    {
        readonly OperationSql operation = new OperationSql();
        [TestMethod()]
        public void ReadStudentsTest()
        {
            operation.ReadStudents();
        }

        [TestMethod()]
        public void CreateStudentTest()
        {
            Student student = new Student
            {
                Name = "Ingrid",
                Surname = "Pardo",
                Birthday = new DateTime(2002, 02, 17)
            };
            operation.CreateStudent(student);
        }

        [TestMethod()]
        public void UpdateStudentTest()
        {
            operation.UpdateStudent(1,"Paula");
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            operation.DeleteStudent(1402);
        }    }
}