using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISUPORTE.Models
{
    public class ProvenanceModel
    {
        public string IdProvenance { get; set; }
        public string ProvenanceDesc { get; set; }
        public string Description { get; set; }
    }

    public class Provenance 
    { 
        public ProvenanceModel Prov { get; set; }
    }

    public class Provenances 
    {
        public List<Provenance> Provs { get; set; }

    }

}
