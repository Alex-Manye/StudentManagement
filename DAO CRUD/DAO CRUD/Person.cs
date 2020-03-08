using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DAO_CRUD
{
    public class Person
    {

        CultureInfo culture = new CultureInfo("es-ES");
        public Person(int id, string name, string surname, DateTime birthday)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.birthday = DateTime.Parse(birthday.ToString(),culture);
        }

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthday { get; set; }

        public string ToString()
        {
            return id.ToString() + " " + name + " " + surname + " " + birthday.ToString();
        }
    }
}
