using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Repositories
{
    public interface IOperacaoFinanceira
    {
        List<OperacaoFinanceira> GetAll();
        OperacaoFinanceira GetById(int id);
        void Create(OperacaoFinanceira operacaoFinanceira);
        void Update(OperacaoFinanceira operacaoFinanceira);
        void Delete(int id);
    }
}