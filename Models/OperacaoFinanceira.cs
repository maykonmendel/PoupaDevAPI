using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDevAPI.Enums;

namespace PoupaDevAPI.Models
{
    public class OperacaoFinanceira : Entity<int>
    {        
        public float Valor { get; set; }
        public TipoOperacao Tipo { get; set; }
        public DateTime DataOperacao { get; set;} 
        public bool EstaDeletado { get; set; }
        public int ContaObjetivoId { get; set; }
        public ContaObjetivo ContaObjetivo { get; set; }

        public OperacaoFinanceira(float valor, TipoOperacao tipo, int contaObjetivoId)
        {            
            Valor = valor;
            Tipo = tipo;
            DataOperacao = DateTime.Now;
            EstaDeletado = false;
            ContaObjetivoId = contaObjetivoId;
        }
    }
}