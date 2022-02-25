using Intercom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISUPORTE.Service.Interfaces
{
    public interface IProcessoService
    {
        public Task<Models.Processos> GetProcesso(int id, string motorista,string banco);
    }

    public interface IAtualizarProcessoService
    {
        public Task<Models.Processos> PutProcesso(int id, string status);
    }
}
