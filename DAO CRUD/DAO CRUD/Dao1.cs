using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using log4net;
using DAO_CRUD.Properties;
using System.Globalization;

namespace DAO_CRUD
{
    public class Dao
    {
        SqlConnection connection;
        SqlCommand command;
        CultureInfo culture = new CultureInfo("af-ZA");
        private static readonly ILog logger = LogManager.GetLogger(typeof(Dao));



        public void Connecter()
        {
            try
            {
                connection = new SqlConnection(Resources.connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                logger.Info(ex);
                throw;
            }
        }

        public int Delete(int id)
        {
            Connecter();
            command = new SqlCommand(Resources.deleteCommand, connection);
            command.Parameters.AddWithValue("@studentid", id);
            int affectedRows = command.ExecuteNonQuery();
            Disconnecter();
            return affectedRows;
        }

        public void Disconnecter()
        {
            connection.Close();
        }
        public int Add(Person person)
        {
            Connecter();
            AddParameters(person, Resources.addCommand);
            TryAddingPerson(out int affectedRows);
            Disconnecter();
            Console.WriteLine("Affected Rows: " + affectedRows);
            return affectedRows;
        }

        private void TryAddingPerson(out int affectedRows)
        {
            try
            {
                affectedRows = command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("This ID is already occupied");
                affectedRows = 0;
            }
        }

        private void AddParameters(Person person, string query)
        {
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", person.id);
            command.Parameters.AddWithValue("@Name", person.name);
            command.Parameters.AddWithValue("@Surname", person.surname);
            command.Parameters.AddWithValue("@Birthday", person.birthday.ToString("d"));
        }

        public Person Read(int personId)
        {
            Connecter();
            command = new SqlCommand(Resources.readCommand, connection);
            SqlDataReader reader = command.ExecuteReader();
            bool found = false;
            Person person = null;
            while (!found)
                IteratePersons(personId, ref reader, ref found, ref person);
            Disconnecter();
            return person;
        }

        private void IteratePersons(int personId, ref SqlDataReader reader, ref bool found, ref Person person)
        {
            try
            {
                reader.Read();
                string id = string.Format("{0}", reader[0]);
                person = PersonFound(ref found, id, reader, personId);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The person is not found");
            }
        }

        public Person PersonFound(ref bool found, string id, SqlDataReader reader, int personId)
        {
            if (int.TryParse(id, out int result) && result == personId)
            {
                found = true;
                Person person = new Person(int.Parse(id), string.Format("{0}", reader[1]),
                    string.Format("{0}", reader[2]), DateTime.Parse(string.Format("{0}", reader[3]), culture));
                //Console.WriteLine(DateTime.Parse(string.Format("{0}", reader[3])).ToString("d"));
                Disconnecter();
                return person;
            }
            return null;
        }
        public int Update(Person person)
        {
            Connecter();
            AddParameters(person, Resources.updateCommand);
            int affectedRows = command.ExecuteNonQuery();
            Disconnecter();
            Console.WriteLine("Affected Rows: " + affectedRows);
            return affectedRows;
        }
        
        public Person Read1(int id)
        {
            Connecter();
            command = new SqlCommand(Resources.read1Command, connection);
            try
            {
                SqlDataReader reader1 = command.ExecuteReader();
                Disconnecter();
                return new Person(id, string.Format("{0}", reader1[1]),
                        string.Format("{0}", reader1[2]), DateTime.Parse(string.Format("{0}", reader1[3]), culture));
            }
            catch { throw; }
        }
    }

}
