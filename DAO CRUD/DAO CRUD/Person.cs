using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_CRUD
{
    public class Person
    {
        public Person(int id, string name, string surname, DateTime birthday)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthday { get; set; }
    }
}
