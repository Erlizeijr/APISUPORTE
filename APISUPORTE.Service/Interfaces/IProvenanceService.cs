using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISUPORTE.Service.Interfaces
{
    interface IProvenanceService
    {
        public Task<Util.Mensagem> InsertProvenance(string banco, string provenanceDesc, string description);
    }
}
