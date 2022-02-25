using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISUPORTE.Service.DB
{

    public class Connection
    {
        SqlConnection conn = new SqlConnection();

        private static string server = @".\SQLEXPRESS";
        private static string dataBase = "SBNDB000";
        private static string user = "sa";
        private static string password = "sa";

        public static string StrCon
        {
            get
            {
                return "Data Source=" + server +
                  ";Integrated Security=True ; Initial Catalog=" + dataBase +
                  ";User ID =" + user + "; Password = " + password;
            }
        }
        //metodo conectar

        public SqlConnection Conectar(string banco)
        {
           conn.ConnectionString =  "Data Source=" + server +
                  ";Integrated Security=True ; Initial Catalog=" + banco +
                  ";User ID =" + user + "; Password = " + password; ;
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        //metodo desconectar
        public SqlConnection Desconectar()

        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }

    }
}
