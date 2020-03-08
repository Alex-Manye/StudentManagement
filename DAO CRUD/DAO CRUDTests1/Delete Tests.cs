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
    public abstract class DeleteTestsBase
    {
        public Person person;
        public Dao dao;
        [TestInitialize]
        public void DeleteTestsSetup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao = new Dao();
            dao.Delete(person.id);
            dao.Add(person);
        }
        [TestCleanup]
        public void DeleteTestsCleanup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao.Delete(person.id);

        }
    }
    [TestClass()]
    public class AddTests : DeleteTestsBase
    {
        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(1, dao.Delete(person.id));
        }
        [TestMethod()]
        public void AddRepeatedTest()
        {
            Assert.AreEqual(1, dao.Delete(person.id));
            Assert.AreEqual(0, dao.Delete(person.id));
        }
    }
}