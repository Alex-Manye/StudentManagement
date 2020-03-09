using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseFirstEntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataFirstEntityFirst.Entity;

namespace DatabaseFirstEntityFramework.Entity.Tests
{
    [TestClass()]
    public class OperationSqlTests
    {
        [TestMethod()]
        public void ReadStudentsTest()
        {
            OperationSql.ReadStudents();
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
            OperationSql.CreateStudent(student);
        }

        [TestMethod()]
        public void UpdateStudentTest()
        {
            OperationSql.UpdateStudent(1,"Paula");
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            OperationSql.DeleteStudent(1);
        }
    }
}