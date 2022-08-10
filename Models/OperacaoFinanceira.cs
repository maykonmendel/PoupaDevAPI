using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDevAPI.Enums;

namespace PoupaDevAPI.Models
{
    public class OperacaoFinanceira
    {
        public int Id { get; private set; }
        public decimal Valor { get; private set; }
        public TipoOperacao Tipo { get; private set; }
        public DateTime DataOperacao { get; private set;}

        public OperacaoFinanceira(decimal valor)
        {
            Id = new Random().Next(1, 1000);
            Valor = valor;
            //Tipo = tipo;
            DataOperacao = DateTime.Now;
        }

    }
}