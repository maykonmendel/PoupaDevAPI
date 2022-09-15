using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.DTO
{
    public class ObjetivoFinanceiroInputDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public float ValorObjetivo { get; set; }

        public ObjetivoFinanceiroInputDTO(string titulo, string descricao, float valorObjetivo)
        {
            Titulo = titulo;
            Descricao = descricao;
            ValorObjetivo = valorObjetivo;
        }
    }
}