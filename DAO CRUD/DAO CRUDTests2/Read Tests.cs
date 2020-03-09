using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO_CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_CRUD.Tests
{
    [TestClass]
    public abstract class ReadTestsBase
    {
        public Person person;
        public Dao dao;
        [ClassInitialize]
        public void ReadClassSetup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao = new Dao();
            dao.Delete(person.id);
        }
        [TestInitialize]
        public void ReadTestsSetup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao = new Dao();
            dao.Add(person);
        }
        [TestCleanup]
        public void ReadTestsCleanup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao.Delete(person.id);

        }
    }
    [TestClass()]
    public class ReadTests : ReadTestsBase
    {
        [TestMethod()]
        public void ReadTest()
        {
            Person readPerson = dao.Read(person.id);
            Assert.AreEqual(person.ToString(), readPerson.ToString());
            Console.WriteLine(person.ToString());
        }
    }
}