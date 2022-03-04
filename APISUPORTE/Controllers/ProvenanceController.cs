using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISUPORTE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvenanceController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Util.Mensagem))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult InsertProvenance( [FromQuery] string banco, [FromBody] Models.ProvenanceModel dados)
        {
            var inserir = new Service.ProvenanceService();
            var post = inserir.InsertProvenance( banco, dados.ProvenanceDesc , dados.Description);
            return Ok("Teste");
        }
    }
}
