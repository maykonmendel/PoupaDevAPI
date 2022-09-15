using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.DTO.ContaObjetivo
{
    public class ContaObjetivoInputDTO
    {
        public float SaldoAtual { get; set; }
        public float SaldoAnterior { get; set; }
        public int ObjetivoFinanceiroId { get; set; }

        public ContaObjetivoInputDTO(float saldoAtual, float saldoAnterior, int objetivoFinanceiroId)
        {
            SaldoAtual = saldoAtual;
            SaldoAnterior = saldoAnterior;
            ObjetivoFinanceiroId = objetivoFinanceiroId;
        }
    }
}