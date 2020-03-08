using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using log4net;

namespace DAO_CRUD
{
    public class Class1
    {
        SqlConnection connection;
        SqlCommand command;
        private static readonly ILog logger = LogManager.GetLogger(typeof(Class1));
    }
}
