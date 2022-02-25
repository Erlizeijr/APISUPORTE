using System;
using System.Collections.Generic;

namespace APISUPORTE.Models
{
    public class ProcessoModel
    {
        public int IdProcesso { get; set; }
        public string Centro { get; set; }
        public string NroCartao { get; set; }
        public string CodVeiculo { get; set; }
        public string Motorista { get; set; }
        public string Transportadora { get; set; }
        public string NroDocumento { get; set; }
        public string TipoDocto { get; set; }
        public string Destinatario { get; set; }
        public string TipoOperacao { get; set; }
        public string ProcessoStatus { get; set; }
        public string DataVigenciaInicial { get; set; }
        public string DataVigenciaFinal { get; set; }
        public string PesoTara { get; set; }
        public string PesoBruto { get; set; }
        public string TipoOrigem { get; set; }
        public string DataRegistro { get; set; }
    }
    public class Processo
    {
        public ProcessoModel Movement { get; set; }

    }

    public class Processos
    {
        public List<Processo> Movements { get; set; }
    }
}


