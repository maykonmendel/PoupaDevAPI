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

        public void CreateOrUpdate(OperacaoFinanceira operacaoFinanceira)
        {
            _context.Entry(operacaoFinanceira).State = operacaoFinanceira.Id == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var operacaoFinanceira = _context.OperacoesFinanceiras.SingleOrDefault(p => p.Id == id);

            if (operacaoFinanceira != null)
            {
                _context.OperacoesFinanceiras.Remove(operacaoFinanceira);
                _context.SaveChanges();
            }
        }

        public List<OperacaoFinanceira> GetAll()
        {
            return _context.OperacoesFinanceiras.ToList();
        }
        

        public OperacaoFinanceira GetById(int id)
        {
            return _context.OperacoesFinanceiras.SingleOrDefault(p => p.Id == id);
        }       
    }
}