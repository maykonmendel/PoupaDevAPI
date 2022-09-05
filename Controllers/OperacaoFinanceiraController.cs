using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoupaDevAPI.Models;
using PoupaDevAPI.Repositories;

namespace PoupaDevAPI.Controllers
{
    [Route("operacaofinanceira")]
    public class OperacaoFinanceiraController : Controller
    {
        private readonly OperacaoFinanceiraRepository _repository;

        public OperacaoFinanceiraController(OperacaoFinanceiraRepository repository)
        {
            _repository = repository;
        }

        //GET: api/operacaoFinanceira
        [HttpGet]
        public async Task<ActionResult<OperacaoFinanceiraRepository>> GetAll()
        {
            var listaOperacoesFinanceiras = await _repository.GetAll();
            return Ok(listaOperacoesFinanceiras);
        }

        //GET: api/operacaoFinanceira/{id} 
        [HttpGet("{id}")]
        public async Task<ActionResult<OperacaoFinanceira>> GetById(int id)
        {
            var operacaoFinanceira = await _repository.GetById(id);
            return Ok(operacaoFinanceira);
        }

        //POST: api/operacaoFinanceira
        [HttpPost]
        public async Task<ActionResult<OperacaoFinanceira>> Create([FromBody] OperacaoFinanceira operacaoFinanceira)
        {
            operacaoFinanceira = await _repository.Create(operacaoFinanceira);
            return Ok();
        }

        //PUT: api/operacaoFinanceira/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<OperacaoFinanceira>> Update([FromBody] OperacaoFinanceira operacaoFinanceira, int id)
        {
            operacaoFinanceira = await _repository.Update(operacaoFinanceira, id);
            return Ok(operacaoFinanceira);
        }

        //DELETE: api/operacaoFinanceira/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}