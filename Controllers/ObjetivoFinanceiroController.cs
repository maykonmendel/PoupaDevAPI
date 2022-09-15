using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoupaDevAPI.DTO;
using PoupaDevAPI.DTO.ObjetivoFinanceiro;
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
        public async Task<ActionResult<ObjetivoFinanceiroOutputGetByIdDTO>> GetById(int id)
        {
            var objetivoFinanceiro = await _repository.GetById(id);
            var objetivoFinanceiroOutputDTO = new ObjetivoFinanceiroOutputGetByIdDTO(objetivoFinanceiro.Id, objetivoFinanceiro.Titulo, objetivoFinanceiro.Descricao, objetivoFinanceiro.ValorObjetivo);

            return Ok(objetivoFinanceiroOutputDTO);
        }

        //POST: api/objetivoFinanceiro
        [HttpPost]
        public async Task<ActionResult<ObjetivoFinanceiroInputDTO>> Create([FromBody]ObjetivoFinanceiroInputDTO objetivoFinanceiroInputDTO)
        {
            var objetivoFinanceiro = await _repository.Create(new ObjetivoFinanceiro(objetivoFinanceiroInputDTO.Titulo, objetivoFinanceiroInputDTO.Descricao, objetivoFinanceiroInputDTO.ValorObjetivo));            
            return Ok(objetivoFinanceiro);
        }

        //PUT: api/objetivoFinanceiro/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ObjetivoFinanceiroInputDTO>> Update([FromBody] ObjetivoFinanceiroInputDTO objetivoFinanceiroInputDTO, int id)
        {
            var objetivoFinanceiro = await _repository.Update(new ObjetivoFinanceiro(objetivoFinanceiroInputDTO.Titulo, objetivoFinanceiroInputDTO.Descricao, objetivoFinanceiroInputDTO.ValorObjetivo), id);
            return Ok(objetivoFinanceiro);
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