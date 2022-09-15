using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.DTO.ObjetivoFinanceiro
{
    public class ObjetivoFinanceiroOutputGetByIdDTO
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public float ValorObjetivo { get; private set; }

        public ObjetivoFinanceiroOutputGetByIdDTO(int id, string titulo, string descricao, float valorObjetivo)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            ValorObjetivo = valorObjetivo;
        }
    }
}