using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoupaDevAPI.Models;
using PoupaDevAPI.Repositories;

namespace PoupaDevAPI.Controllers
{
    [Route("objetivofinanceiro")]
    public class ObjetivoFinanceiroController : Controller
    {
        private readonly ObjetivoFinanceiroRepository _repository;

        public ObjetivoFinanceiroController(ObjetivoFinanceiroRepository repository)
        {
            _repository = repository;
        }

        //GET: api/objetivoFinanceiro
        [HttpGet]
        public async Task<ActionResult<ObjetivoFinanceiro>> GetAll()
        {
            var listaObjetivosFinanceiros = await _repository.GetAll();
            return Ok(listaObjetivosFinanceiros);
        }

        //GET: api/objetivoFinanceiro/{id} 
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjetivoFinanceiro>> GetById(int id)
        {
            var objetivoFinanceiro = await _repository.GetById(id);
            return Ok(objetivoFinanceiro);
        }

        //POST: api/objetivoFinanceiro
        [HttpPost]
        public async Task<ActionResult<ObjetivoFinanceiro>> Create([FromBody]ObjetivoFinanceiro objetivoFinanceiro)
        {
            objetivoFinanceiro = await _repository.Create(objetivoFinanceiro);
            return Ok();
        }

        //PUT: api/objetivoFinanceiro/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ObjetivoFinanceiro>> Update([FromBody] ObjetivoFinanceiro objetivoFinanceiro, int id)
        {
            objetivoFinanceiro = await _repository.Update(objetivoFinanceiro, id);
            return Ok();
        }

        //DELETE: api/objetivoFinanceiro/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}