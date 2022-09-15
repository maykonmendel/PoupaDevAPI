using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.Models
{
    public class ContaObjetivo : Entity<int>
    {
        public float SaldoAtual { get; set; }
        public float SaldoAnterior { get; set; }
        public int ObjetivoFinanceiroId { get; set; }        
        public ObjetivoFinanceiro ObjetivoFinanceiro { get; set; }
        public bool EstaDeletado { get; set; }
        public List<OperacaoFinanceira> ListaOperacoes { get; set; }


        public ContaObjetivo(float saldoAtual, float saldoAnterior, int objetivoFinanceiroId)
        {
            SaldoAtual = saldoAtual;
            SaldoAnterior = saldoAnterior;
            EstaDeletado = false;
            ObjetivoFinanceiroId = objetivoFinanceiroId;
            ListaOperacoes = new List<OperacaoFinanceira>();
        }
    }
}