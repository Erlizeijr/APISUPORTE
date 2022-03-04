using Intercom.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APISUPORTE.Util;
using APISUPORTE.Service;


namespace APISUPORTE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProcessoController : ControllerBase
    {


        // GET api/<ProcessoController>/5
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Processos))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetProcesso([FromQuery] int id, string motorista, string banco)
        {
            var _processoService = new ProcessoService();
            var processo = _processoService.GetProcesso(id, motorista, banco);

            if (processo.Result == null)
            {
                var msg = new Mensagem()
                {
                    Msg = "Processo não encontrado"
                };
                return NotFound(msg);
            }

            return Ok(processo.Result);
            //return Ok("Teste");
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Processos))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProcesso(int id,[FromQuery] string banco, [FromBody] Models.ProcessoModel dados)
        {
            var atualizar = new Service.ProcessoService();
            var update = atualizar.UpdateProcesso(id,banco, dados.ProcessoStatus);
            return Ok(update.Result);
        }

    }


}