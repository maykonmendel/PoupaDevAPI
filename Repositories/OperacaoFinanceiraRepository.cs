using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoupaDevAPI.Context;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Repositories
{
    public class OperacaoFinanceiraRepository : IOperacaoFinanceira
    {
        private readonly PoupaDevAPIContext _context;

        public OperacaoFinanceiraRepository(PoupaDevAPIContext context) 
        {
            _context = context;
        }

        public void Create(OperacaoFinanceira operacaoFinanceira)
        {
            _context.OperacoesFinanceiras.Add(operacaoFinanceira);
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

        public void Update(OperacaoFinanceira operacaoFinanceira)
        {
            _context.Entry(operacaoFinanceira).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}