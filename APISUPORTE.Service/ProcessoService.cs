using APISUPORTE.Service.Interfaces;
using Intercom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISUPORTE.Models;
using System.Data.SqlClient;
using APISUPORTE.Service.DB;
using System.Data;
using APISUPORTE.Util;

namespace APISUPORTE.Service
{
    public class ProcessoService : IProcessoService
    {
        
        public async Task<Models.Processos> GetProcesso(int id, string motorista,string banco)
        {
            SqlCommand cmd = new SqlCommand();
            Connection cn = new Connection();
            try
            {

                string newId = id.ToString();
                if (id == 0)
                {
                    newId = "null";
                }
                ////string newMotorista = motorista;
                //if (motorista == null || motorista == "")
                //{
                //    newMotorista = "null";
                //}


                string sqlQuery = "EXEC Stpprv_AplPROCESSO_Selecionar " + newId + ",null,null,null,null,null,null,null,null" +
                    ",null,null,null,null,null,null,null,null";
                cmd.CommandText = sqlQuery;
                cmd.Connection = cn.Conectar(banco);
                cmd.ExecuteReader();
                cn.Desconectar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable TabelaProcesso = new DataTable();
                da.Fill(TabelaProcesso);

                var listMovimento = new List<Models.Processo>();

                foreach (DataRow dataRow in TabelaProcesso.Rows)
                {
                    var proc = new Models.ProcessoModel();
                    proc.IdProcesso = int.Parse(dataRow["IdProcesso"].ToString());
                    proc.Centro = dataRow["Centro"].ToString();
                    proc.NroCartao = dataRow["NroCartao"].ToString();
                    proc.CodVeiculo = dataRow["CodVeiculo"].ToString();
                    proc.Motorista = dataRow["Motorista"].ToString();
                    proc.Transportadora = dataRow["Transportadora"].ToString();
                    proc.NroDocumento = dataRow["NroDocumento"].ToString();
                    proc.TipoDocto = dataRow["TipoDocto"].ToString();
                    proc.Destinatario = dataRow["Destinatario"].ToString();
                    proc.TipoOperacao = dataRow["TipoOperacao"].ToString();
                    proc.ProcessoStatus = dataRow["ProcessoStatus"].ToString();
                    proc.DataVigenciaInicial = dataRow["DataVigenciaInicial"].ToString();
                    proc.DataVigenciaFinal = dataRow["DataVigenciaFinal"].ToString();
                    proc.PesoTara = dataRow["PesoTara"].ToString();
                    proc.PesoBruto = dataRow["PesoBruto"].ToString();
                    proc.TipoOrigem = dataRow["TipoOrigem"].ToString();
                    proc.DataRegistro = dataRow["DataRegistro"].ToString();
                    var procs = new Models.Processo()
                    {
                        Movement = proc
                    };
                    listMovimento.Add(procs);
                }
                var listMovimentos = new Models.Processos
                {
                    Movements = listMovimento
                };
                return listMovimentos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Mensagem> UpdateProcesso(int id, string status,string banco)
        {
            SqlCommand cmd = new SqlCommand();
            Connection cn = new Connection();
            var msg = new Mensagem();

            try
            {
                string sqlQuery = "UPDATE PROCESSO SET CodProcessoStatus ='" + status + "' WHERE IdProcesso = '" + id + "' ";
                cmd.CommandText = sqlQuery;
                cmd.Connection = cn.Conectar(banco);
                cmd.ExecuteNonQuery();
                cn.Desconectar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable TabelaProcesso = new DataTable();
                da.Fill(TabelaProcesso);

                if (TabelaProcesso.Rows.Count == 0)
                {
                    msg.Msg = "Processo nao encontrado";
                }

                else if (string.IsNullOrEmpty(status))

                {
                    msg.Msg =  "Status inválido ou nulo";
                }

                else
                {
                    string sqlQuery2 = "UPDATE PROCESSO SET CodProcessoStatus ='" + status + "' WHERE IdProcesso = '" + id + "' ";
                    cmd.CommandText = sqlQuery;
                    cmd.Connection = cn.Conectar(banco);
                    cmd.ExecuteReader();
                    cn.Desconectar();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    DataTable TabelaProcesso2 = new DataTable();
                    da2.Fill(TabelaProcesso);

                    msg.Msg =  "Processo atualizado com sucesso";
                }
                return msg;
            }
            catch (Exception ex)
            {
                msg.Msg = "Erro";
                return msg;
            }

        }
    }

}







