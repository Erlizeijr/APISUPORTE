using APISUPORTE.Models;
using APISUPORTE.Service.DB;
using APISUPORTE.Service.Interfaces;
using APISUPORTE.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISUPORTE.Service
{
    public class ProvenanceService : IProvenanceService
    {
        public async Task<Util.Mensagem> InsertProvenance(string banco, string provenanceDesc, string description)
        {
            SqlCommand cmd = new SqlCommand();
            Connection cn = new Connection();
            Mensagem msg = new Mensagem();

            try
            {
                string sqlQuery = "INSERT INTO PROVENANCE ( ProvenanceDesc, Description ) VALUES( '"+provenanceDesc+"', '"+ description+"')";
                cmd.CommandText = sqlQuery;
                cmd.Connection = cn.Conectar(banco);
                cmd.ExecuteNonQuery();
                cn.Desconectar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable TabelaProvenance = new DataTable();
                da.Fill(TabelaProvenance);
                msg.Msg = "Dados inseridos com sucesso";
                return msg;

            }


            catch(Exception ex)
            {
                msg.Msg = "Erro";
                return msg;

            }

        }


    }
}
