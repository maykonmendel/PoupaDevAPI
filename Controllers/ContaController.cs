using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoupaDevAPI.Models;
using PoupaDevAPI.Repositories;

namespace PoupaDevAPI.Controllers
{
    [Route("conta")]
    public class ContaController : Controller
    {
        private readonly ContaObjetivoRepository _repository;

        public ContaController(ContaObjetivoRepository repository)
        {
            _repository = repository;
        }

        //POST: api/conta
        [HttpPost]
        public async Task<ActionResult<ContaObjetivo>> Create([FromBody] ContaObjetivo conta)
        {
            conta = await _repository.Create(conta);
            return Ok();
        }

        //PATCH: api/conta/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<ContaObjetivo>> Update([FromBody] ContaObjetivo conta, int id)
        {
            conta = await _repository.Update(conta, id);
            return Ok();
        }

        //DELETE: api/conta/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok();
        }

        //GET: api/conta
        [HttpGet]
        public async Task<ActionResult<ContaObjetivo>> GetAll()
        {
            var listaContas = await _repository.GetAll();
            return Ok(listaContas);
        }

        //GET: api/conta/{id} 
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaObjetivo>> GetById(int id)
        {
            var conta = await _repository.GetById(id);
            return Ok(conta);
        }
    }
}