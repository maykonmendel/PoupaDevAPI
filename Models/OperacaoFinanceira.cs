using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDevAPI.Enums;

namespace PoupaDevAPI.Models
{
    public class OperacaoFinanceira : Entity<int>
    {        
        public decimal Valor { get; set; }
        public TipoOperacao Tipo { get; set; }
        public DateTime DataOperacao { get; set;} 
        public int ObjetivoFinanceiroId { get; set; }
        public bool EstaDeletado { get; set; }

        public OperacaoFinanceira(decimal valor, TipoOperacao tipo)
        {            
            Valor = valor;
            Tipo = tipo;
            DataOperacao = DateTime.Now;
            EstaDeletado = false;
        }

    }
}