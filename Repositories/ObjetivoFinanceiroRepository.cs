using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoupaDevAPI.Context;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Repositories
{
    public class ObjetivoFinanceiroRepository : IRepositoryBase<ObjetivoFinanceiro, int>
    {
        private readonly PoupaDevAPIContext _context;

        public ObjetivoFinanceiroRepository(PoupaDevAPIContext context)
        {
            _context = context;
        }

        public async Task<ObjetivoFinanceiro> Create(ObjetivoFinanceiro objetivoFinanceiro)
        {
            _context.ObjetivosFinanceiros.Add(objetivoFinanceiro);
            await _context.SaveChangesAsync();

            return objetivoFinanceiro;
        }

        public async Task<ObjetivoFinanceiro> Update(ObjetivoFinanceiro objetivoFinanceiro, int id) 
        {
            objetivoFinanceiro = _context.ObjetivosFinanceiros.FirstOrDefault(x => x.Id == id);

            if(objetivoFinanceiro != null)
            {
                _context.Entry(objetivoFinanceiro).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }            

            return objetivoFinanceiro;
        }

        public async Task Delete(int id)
        {
            var objetivoFinanceiro = await _context.ObjetivosFinanceiros.FirstOrDefaultAsync(p => p.Id == id);

            if(objetivoFinanceiro != null)
            {
                _context.ObjetivosFinanceiros.Remove(objetivoFinanceiro);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ObjetivoFinanceiro>> GetAll()
        {
            return await _context.ObjetivosFinanceiros.ToListAsync();
        }

        public async Task<ObjetivoFinanceiro> GetById(int id)
        {
            return await _context.ObjetivosFinanceiros.SingleOrDefaultAsync(p => p.Id == id);            
        }        
    }
}