using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeFirstEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntityFramework.Tests
{
    [TestClass()]
    public class OperationSQLTests
    {
        [TestMethod()]
        public void ReadStudentsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateStudentTest()
        {
            //Assert.Fail();
            /*
            StudentDao student = new StudentDao {
                StudentName = "Maria",
                StudentLastName = "Parrado",
                BirthDate = new DateTime(2002,02,17)
            };

            OperationSQL.CreateStudent(student);
           */
          


            
               
        }

        [TestMethod()]
        public void UpdateStudentTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteStudentTest()
        {
            int id = 5;
            OperationSQL.DeleteStudent(id);
        }
    }
}