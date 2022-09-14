using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.Models
{
    public class ContaObjetivo : Entity<int>
    {
        public decimal SaldoAtual { get; set; }
        public decimal SaldoAnterior { get; set; }
        public int ObjetivoFinanceiroId { get; set; }        
        public ObjetivoFinanceiro ObjetivoFinanceiro { get; set; }
        public bool EstaDeletado { get; set; }
        public List<OperacaoFinanceira> ListaOperacoes { get; set; }


        public ContaObjetivo(decimal saldoAtual, decimal saldoAnterior, int objetivoFinanceiroId)
        {
            SaldoAtual = saldoAtual;
            SaldoAnterior = saldoAnterior;
            EstaDeletado = false;
            ObjetivoFinanceiroId = objetivoFinanceiroId;
            ListaOperacoes = new List<OperacaoFinanceira>();
        }
    }
}