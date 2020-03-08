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
    public abstract class AddTestsBase
    {
        public Person person;
        public Dao dao;

        [ClassInitialize]
        public void AddClassSetup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao = new Dao();
            dao.Delete(person.id);
        }
        [TestInitialize]
        public void AddTestSetup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao = new Dao();
        }
        [TestCleanup]
        public void AddTestCleanup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao.Delete(person.id);
        }
    }
    [TestClass()]
    public class AddTests : AddTestsBase
    {
        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(1, dao.Add(person));
        }
        [TestMethod()]
        public void AddRepeatedTest()
        {
            Assert.AreEqual(1, dao.Add(person));
            Assert.AreEqual(0, dao.Add(person));
        }
    }
}