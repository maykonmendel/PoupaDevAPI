using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDevAPI.Enums;

namespace PoupaDevAPI.DTO
{
    public class OperacaoFinanceiraInputDTO
    {
        public float Valor { get; set; }
        public TipoOperacao Tipo { get; set; }
        public int ContaObjetivoId { get; set; }

        public OperacaoFinanceiraInputDTO(float valor, TipoOperacao tipo, int contaObjetivoId)
        {
            Valor = valor;
            Tipo = tipo;
            ContaObjetivoId = contaObjetivoId;
        }
    }
}