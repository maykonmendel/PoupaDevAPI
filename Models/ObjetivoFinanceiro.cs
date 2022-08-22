using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.Models
{
    public class ObjetivoFinanceiro : IEntity<int>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal ValorObjetivo { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<OperacaoFinanceira> ListaOperacoes { get; set; }

        public ObjetivoFinanceiro(string titulo, string descricao, decimal valorObjetivo)
        {            
            Titulo = titulo;
            Descricao = descricao;
            ValorObjetivo = valorObjetivo;
            DataCriacao = DateTime.Now;
            ListaOperacoes = new List<OperacaoFinanceira>();
        }
    }
}