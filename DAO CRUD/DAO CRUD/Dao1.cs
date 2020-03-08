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
        CultureInfo culture = new CultureInfo("es-ES");
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
            int affectedRows = 0;
            affectedRows = TryAddingPerson(affectedRows);
            Disconnecter();
            Console.WriteLine("Affected Rows: " + affectedRows);
            return affectedRows;
        }

        private int TryAddingPerson(int affectedRows)
        {
            try
            {
                affectedRows = command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("This ID is already occupied");
            }

            return affectedRows;
        }

        private void AddParameters(Person person, string query)
        {
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", person.id);
            command.Parameters.AddWithValue("@Name", person.name);
            command.Parameters.AddWithValue("@Surname", person.surname);
            command.Parameters.AddWithValue("@Birthday", person.birthday.ToString("d",culture));
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
            catch (InvalidOperationException ex)
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
    }

}
