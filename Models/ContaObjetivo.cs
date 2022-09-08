using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.Models
{
    public class ContaObjetivo : Entity<int>
    {
        public decimal SaldoAtual { get; set; }
        public int ObjetivoFinanceiroId { get; set; }
        public ObjetivoFinanceiro ObjetivoFinanceiro { get; set; }

        public ContaObjetivo(decimal saldoAtual)
        {
            SaldoAtual = saldoAtual;
        }
    }
}