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
    public class Class1
    {
        SqlConnection connection;
        SqlCommand command;
        private static readonly ILog logger = LogManager.GetLogger(typeof(Class1));



        private void Connecter()
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
        private void Disconnecter()
        {
            connection.Close();
        }

    }

}
