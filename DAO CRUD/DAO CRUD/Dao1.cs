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
        public void Disconnecter()
        {
            connection.Close();
        }
        public void Add(Person person)
        {
            Connecter();
            command = new SqlCommand(Resources.addCommand, connection);
            command.Parameters.AddWithValue("@StudentId", person.id);
            command.Parameters.AddWithValue("@Name", person.name);
            command.Parameters.AddWithValue("@Surname", person.surname);
            command.Parameters.AddWithValue("@Birthday", person.birthday.ToString("d"));
            int affectedRows = command.ExecuteNonQuery();
            Disconnecter();
            Console.WriteLine("Affected Rows: " + affectedRows);
        }
    }

}
