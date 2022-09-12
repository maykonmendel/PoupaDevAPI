using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoupaDevAPI.Context;
using PoupaDevAPI.Exceptions;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Repositories
{
    public class OperacaoFinanceiraRepository : IRepositoryBase<OperacaoFinanceira, int>
    {
        private readonly PoupaDevAPIContext _context;

        public OperacaoFinanceiraRepository(PoupaDevAPIContext context) 
        {
            _context = context;
        }

        public async Task<OperacaoFinanceira> Create(OperacaoFinanceira operacaoFinanceira)
        {
            var operacao = _context.OperacoesFinanceiras.Add(operacaoFinanceira);

            if (operacao.State != EntityState.Added)
            {
                throw new BadRequestException("Erro ao cadastrar uma nova Operação Financeira. Tente novamente.");
            }

            _context.OperacoesFinanceiras.Add(operacaoFinanceira);
            await _context.SaveChangesAsync();

            return operacaoFinanceira;
        }

        public async Task<OperacaoFinanceira> Update(OperacaoFinanceira operacaoFinanceira, int id)
        {
            operacaoFinanceira = await _context.OperacoesFinanceiras.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (operacaoFinanceira == null)
            {
                throw new BadRequestException("Operação Financeira não cadastrada!");
            }

            _context.Entry(operacaoFinanceira).State = EntityState.Modified;
            await _context.SaveChangesAsync();           
            return operacaoFinanceira;
        }

        public async Task<List<OperacaoFinanceira>> GetDeleted()
        {
            var listaOperacoesDeletadas = _context.OperacoesFinanceiras.Where(x => x.EstaDeletado == true).ToListAsync();

            if (listaOperacoesDeletadas == null)
            {
                throw new NotFoundException("Não há resultado a ser exibido!");
            }

            return await listaOperacoesDeletadas;
        }

        public async Task Delete(int id)
        {
            var operacaoFinanceira = await _context.OperacoesFinanceiras.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (operacaoFinanceira == null)
            {
                throw new BadRequestException("Operação Financeira não cadastrado!");
            }

            if (operacaoFinanceira.EstaDeletado != true)
            {
                operacaoFinanceira.EstaDeletado = true;
                _context.Entry(operacaoFinanceira).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<OperacaoFinanceira>> GetAll()
        {
            var listOperacoesFinanceiras = _context.OperacoesFinanceiras.IgnoreQueryFilters().AsNoTracking().ToListAsync();

            if (listOperacoesFinanceiras == null)
            {
                throw new NotFoundException("Não há resultado a ser exibido!");
            }

            return await listOperacoesFinanceiras;
        }        

        public async Task<OperacaoFinanceira> GetById(int id)
        {
            var operacaoFinanceira = _context.OperacoesFinanceiras.IgnoreQueryFilters().AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

            if (operacaoFinanceira == null)
            {
                throw new NotFoundException("Operação Financeira não cadastrada!");
            }

            return await operacaoFinanceira;
        }       
    }
}