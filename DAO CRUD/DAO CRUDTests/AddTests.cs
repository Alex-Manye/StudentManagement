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
        [TestInitialize]
        public void Setup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao = new Dao();
        }
        [TestCleanup]
        public void CleanupAddTest()
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