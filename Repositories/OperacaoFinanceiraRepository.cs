using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoupaDevAPI.Context;
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
            _context.OperacoesFinanceiras.Add(operacaoFinanceira);
            await _context.SaveChangesAsync();

            return operacaoFinanceira;
        }

        public async Task<OperacaoFinanceira> Update(OperacaoFinanceira operacaoFinanceira, int id)
        {
            operacaoFinanceira = _context.OperacoesFinanceiras.FirstOrDefault(p => p.Id == id);

            if (operacaoFinanceira != null)
            {
                _context.Entry(operacaoFinanceira).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
           
            return operacaoFinanceira;
        }

        public async Task Delete(int id)
        {
            var operacaoFinanceira = await _context.OperacoesFinanceiras.FirstOrDefaultAsync(p => p.Id == id);

            if (operacaoFinanceira != null)
            {
                _context.OperacoesFinanceiras.Remove(operacaoFinanceira);
                await _context.SaveChangesAsync();
            }            
        }

        public async Task<List<OperacaoFinanceira>> GetAll()
        {
            return await _context.OperacoesFinanceiras.ToListAsync();
        }
        

        public async Task<OperacaoFinanceira> GetById(int id)
        {
            return await _context.OperacoesFinanceiras.SingleOrDefaultAsync(p => p.Id == id);
        }       
    }
}