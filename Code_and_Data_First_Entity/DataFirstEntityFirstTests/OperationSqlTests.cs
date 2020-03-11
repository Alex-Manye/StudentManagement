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
            Student studentID = new Student();
            studentID.Studentid = 1402;
            studentID.Name = "Laura";
            operation.UpdateStudent(studentID);
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            Student studentID = new Student();
            studentID.Studentid = 2405;
            operation.DeleteStudent(studentID);
        }   
    }
}