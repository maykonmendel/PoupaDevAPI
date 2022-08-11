using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Repositories
{
    public interface IObjetivoFinanceiroRepository
    {
        List<ObjetivoFinanceiro> GetAll();
        ObjetivoFinanceiro GetById(int id);
        void Create(ObjetivoFinanceiro objetivoFinanceiro);
        void Update(ObjetivoFinanceiro objetivoFinanceiro);
        void Delete(int id);
    }
}