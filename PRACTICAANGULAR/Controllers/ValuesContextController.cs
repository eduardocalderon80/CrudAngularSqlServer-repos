using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRACTICAANGULAR.Contexto;
using PRACTICAANGULAR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRACTICAANGULAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesContextController : ControllerBase
    {
        private readonly ContextRepository contextRepository;

        public ValuesContextController(ContextRepository contextRepository)
        {
            this.contextRepository = contextRepository;
        }

        [HttpGet("todo")]
        public async Task<ActionResult<List<Value>>> Get()
        {
            return await contextRepository.Value.ToListAsync();
        }
    }
}
