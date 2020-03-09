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
    public abstract class Read1TestsBase
    {
        public Person person;
        public Dao dao;
        [ClassInitialize]
        public void Read1ClassSetup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao = new Dao();
            dao.Delete(person.id);
        }
        [TestInitialize]
        public void Read1TestsSetup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao = new Dao();
            dao.Add(person);
        }
        [TestCleanup]
        public void Read1TestsCleanup()
        {
            person = new Person(9781, "Alex", "Manye", DateTime.Today);
            dao.Delete(person.id);

        }
    }
    [TestClass()]
    public class Read1Tests : Read1TestsBase
    {
        [TestMethod()]
        public void Read1Test()
        {
            Person readPerson = dao.Read(person.id);
            Assert.AreEqual(person.ToString(), readPerson.ToString());
            Console.WriteLine(readPerson.ToString());
        }
    }
}