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
    public class ObjetivoFinanceiroRepository : IRepositoryBase<ObjetivoFinanceiro, int>
    {
        private readonly PoupaDevAPIContext _context;

        public ObjetivoFinanceiroRepository(PoupaDevAPIContext context)
        {
            _context = context;
        }

        public async Task<ObjetivoFinanceiro> Create(ObjetivoFinanceiro objetivoFinanceiro)
        {
            var objetivo = _context.ObjetivosFinanceiros.Add(objetivoFinanceiro);

            if (objetivo.State != EntityState.Added)
            {
                throw new BadRequestException("Erro ao cadastrar um novo Objetivo Financeiro. Tente novamente.");
            }

            await _context.SaveChangesAsync();

            return objetivoFinanceiro;
        }

        public async Task<ObjetivoFinanceiro> Update(ObjetivoFinanceiro objetivoFinanceiro, int id) 
        {
            objetivoFinanceiro = _context.ObjetivosFinanceiros.IgnoreQueryFilters().AsNoTracking().FirstOrDefault(x => x.Id == id);

            if(objetivoFinanceiro == null) 
            {
                throw new BadRequestException("Objetivo Financeiro não cadastrado!");
            }

            _context.Entry(objetivoFinanceiro).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return objetivoFinanceiro;
        }

        public async Task Delete(int id)
        {
            var objetivoFinanceiro = await _context.ObjetivosFinanceiros.IgnoreQueryFilters().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (objetivoFinanceiro == null)
            {
                throw new BadRequestException("Objetivo Financeiro não cadastrado!");
            }

            if(objetivoFinanceiro.EstaDeletado != true) 
            {
                objetivoFinanceiro.EstaDeletado = true;
                _context.Entry(objetivoFinanceiro).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }            
        }

        public async Task<List<ObjetivoFinanceiro>> GetAll()
        {
            var listObjetivosFinanceiros = _context.ObjetivosFinanceiros.IgnoreQueryFilters().AsNoTracking().ToListAsync();

            if(listObjetivosFinanceiros == null)
            {
                throw new BadRequestException("Não há resultado a ser exibido!");
            }

            return await listObjetivosFinanceiros;
        }

        public async Task<ObjetivoFinanceiro> GetById(int id)
        {
            var objetivoFinanceiro = _context.ObjetivosFinanceiros.IgnoreQueryFilters().AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

            if (objetivoFinanceiro == null)
            {
                throw new BadRequestException("Objetivo Financeiro não cadastrado!");
            }

            return await objetivoFinanceiro;            
        }        
    }
}