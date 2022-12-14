using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.Models
{
    public class ObjetivoFinanceiro : Entity<int>
    {        
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public float ValorObjetivo { get; set; }
        public DateTime DataCriacao { get; set; }        
        public ContaObjetivo Conta { get; set; }
        public bool EstaDeletado { get; set; }   

        public ObjetivoFinanceiro(string titulo, string descricao, float valorObjetivo)
        {            
            Titulo = titulo;
            Descricao = descricao;
            ValorObjetivo = valorObjetivo;
            DataCriacao = DateTime.Now;
            EstaDeletado = false;            
        }
    }
}