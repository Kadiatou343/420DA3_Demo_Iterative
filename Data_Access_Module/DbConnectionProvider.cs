using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Module
{
    internal class DbConnectionProvider
    {
        private static string connectionString = "Server= .\\SQL2022DEV;Database=demo_iterative;Integrated Security=true;TrustServerCertificate=true;";
        private static SqlConnection? connection;

        public static SqlConnection GetConnexion()
        {
            connection ??= new SqlConnection(connectionString);
            return connection;
        }
    }
}
