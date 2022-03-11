//using APISUPORTE.Models;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace APISUPORTE.Service
//{
//    public class ConectionRadio
//    {
//        #region atributos
//        private string unidadeIp;
//        private string string_conexao;

//        // atributos //
//        //private string string_conexao = "Data Source=NEPRE0004\\GSCSLOCAL;Initial Catalog=SBNDB000;Integrated Security=True";
//        //private string string_conexao = "Data Source=10.83.10.76;Initial Catalog=sbndb000;User ID=aplvb;Password=aplvb";


//        private string query_string;
//        private string[] parametros;

//        public string[] Parametros { get => parametros; set => parametros = value; }
//        public string Query_string { get => query_string; set => query_string = value; }
//        public string UnidadeIp { get => unidadeIp; set => unidadeIp = value; }
//        public string String_conexao { get => string_conexao; set => string_conexao = value; }

//        #endregion
//        #region metodos
//        // metodos //

//        public ConectionRadio(string unidadeIp)
//        {
//            UnidadesModel unidades = new UnidadesModel();

//            this.UnidadeIp = unidades.retornaIPUnoidade(unidadeIp);
//            //this.String_conexao = @"Data Source=NEPRE0008\NEPRE0008;Initial Catalog=SBNDB000;Integrated Security=True";
//            // this.String_conexao = @"Data Source=NEPRE0002\SERVIDOR;Initial Catalog=sbndb000;User ID=aplvb;Password=aplvb";
//            // this.String_conexao = "Data Source=192.168.15.50;Initial Catalog=sbndb000;User ID=aplvb;Password=aplvb";
//            //this.String_conexao = "Data Source=192.168.15.50;Initial Catalog=sbndb000;User ID=aplvb;Password=aplvb";
//            this.String_conexao = @"Data Source=" + this.UnidadeIp + ";Initial Catalog=RMDB000;User ID=aplvb;Password=aplvb";
//        }
//        public SqlDataReader mysql_data_reader()
//        {
//            SqlConnection conexao = new SqlConnection();
//            conexao.ConnectionString = this.String_conexao;
//            conexao.Open();

//            SqlCommand comando = new SqlCommand();
//            comando.CommandText = Query_string;
//            comando.Connection = conexao;

//            SqlDataReader reader = comando.ExecuteReader();
//            conexao.Close();
//            return reader;
//        }

//        public DataTable mysql_data_adapter()
//        {
//            DataTable dtb = new DataTable();

//            SqlConnection conexao = new SqlConnection();
//            conexao.ConnectionString = this.String_conexao;
//            try
//            {
//                conexao.Open();
//                SqlDataAdapter adapter = new SqlDataAdapter(Query_string, conexao);

//                adapter.Fill(dtb);

//                conexao.Dispose();
//                adapter.Dispose();
//            }
//            catch (Exception ex)
//            {
//                return dtb;
//            }
//            finally
//            {
//                conexao.Close();
//            }
//            return dtb;
//        }

//        public bool execute_non_query()
//        {
//            try
//            {
//                SqlConnection conexao = new SqlConnection();
//                conexao.ConnectionString = this.String_conexao;
//                conexao.Open();

//                SqlCommand comando = new SqlCommand();
//                comando.CommandText = Query_string;
//                comando.Connection = conexao;
//                comando.ExecuteNonQuery();

//                conexao.Dispose();
//                comando.Dispose();

//                return true;
//            }
//            catch
//            {

//                return false;
//            }
//            finally
//            {

//            }
//        }
//        #endregion
//    }
//}
