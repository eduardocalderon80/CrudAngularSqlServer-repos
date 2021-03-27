using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRACTICAANGULAR.Models;
using PRACTICAANGULAR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRACTICAANGULAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Persistencia _persistencia;
        public ValuesController(Persistencia persistencia)
        {
            _persistencia = persistencia;
        }

        [HttpGet]
        public async Task<ActionResult<List<Value>>> Get()
        {
            List<Value> lista = await _persistencia.GetValues();
            return lista;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            return await _persistencia.GetValueId(id);
        }

        [HttpPost("insertar")]
        public async Task<ActionResult<int>> Post([FromBody] Value valor)
        {
            return await _persistencia.InsertarValue(valor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] Value valor)
        {
            if (id != valor.Id) {
                return NotFound();
            }
            int result = await _persistencia.UpdateValue(valor);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return Ok(await _persistencia.DeleteValue(id));
        }
    }
}
