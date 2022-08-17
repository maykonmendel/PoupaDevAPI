using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoupaDevAPI.Context;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Repositories
{
    public class ObjetivoFinanceiroRepository : IObjetivoFinanceiroRepository
    {
        private readonly PoupaDevAPIContext _context;

        public ObjetivoFinanceiroRepository(PoupaDevAPIContext context)
        {
            _context = context;
        }

        public void Create(ObjetivoFinanceiro objetivoFinanceiro)
        {
            _context.ObjetivosFinanceiros.Add(objetivoFinanceiro);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var objetivoFinanceiro = _context.ObjetivosFinanceiros.SingleOrDefault(p => p.Id == id);

            if(objetivoFinanceiro != null)
            {
                _context.ObjetivosFinanceiros.Remove(objetivoFinanceiro);
                _context.SaveChanges();
            }
        }

        public List<ObjetivoFinanceiro> GetAll()
        {
            return _context.ObjetivosFinanceiros.ToList();
        }

        public ObjetivoFinanceiro GetById(int id)
        {
            return _context.ObjetivosFinanceiros.SingleOrDefault(p => p.Id == id);            
        }

        public void Update(ObjetivoFinanceiro objetivoFinanceiro)
        {
            _context.Entry(objetivoFinanceiro).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}