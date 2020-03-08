using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using log4net;
using DAO_CRUD.Properties;

namespace DAO_CRUD
{
    public class Dao
    {
        SqlConnection connection;
        SqlCommand command;
        private static readonly ILog logger = LogManager.GetLogger(typeof(Dao));



        public void Connecter()
        {
            try
            {
                connection = new SqlConnection(Resources.connectionString);
                connection.Open();
                //MessageBox.Show("Connection opened");
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
            command = new SqlCommand(Resources.addCommand, connection);
            command.Parameters.AddWithValue("@Id", person.id);
            command.Parameters.AddWithValue("@Name", person.name);
            command.Parameters.AddWithValue("@Surname", person.surname);
            command.Parameters.AddWithValue("@Birthday", person.birthday.ToString("d"));
            int affectedRows = 0;
            try
            {
                affectedRows = command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("This ID is already occupied");
            }
            Disconnecter();
            Console.WriteLine("Affected Rows: " + affectedRows);
            return affectedRows;
        }
        public Person Read(int personId)
        {
            Connecter();
            command = new SqlCommand(Resources.readCommand, connection);
            SqlDataReader reader = command.ExecuteReader();
            bool found = false;
            Person person = null;
            while (reader.Read() && !found)
            {
                string id = string.Format("{0}", reader[0]);
                person = PersonFound(ref found, id, reader, personId);
            }
            Disconnecter();
            return person;
        }
        public Person PersonFound(ref bool found, string id, SqlDataReader reader, int personId)
        {
            if (int.TryParse(id, out int result) && result == personId)
            {
                found = true;
                Person person = new Person(int.Parse(id), string.Format("{0}", reader[1]),
                    string.Format("{0}", reader[2]), DateTime.Parse(string.Format("{0}", reader[3])));
                Disconnecter();
                return person;
            }
            return null;
        }
    }

}
