using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.Models
{
    public class ObjetivoFinanceiro
    {
        public int Id { get; private set; }
        public string? Titulo { get; private set; }
        public string? Descricao { get; private set; }
        public decimal? ValorObjetivo { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public int OperacaoFinanceiraId { get; private set; }
        public List<OperacaoFinanceira> Operacoes { get; private set; }

        public ObjetivoFinanceiro(string? titulo, string? descricao, decimal? valorObjetivo)
        {            
            Titulo = titulo;
            Descricao = descricao;
            ValorObjetivo = valorObjetivo;
            DataCriacao = DateTime.Now;
            Operacoes = new List<OperacaoFinanceira>();
        }
    }
}