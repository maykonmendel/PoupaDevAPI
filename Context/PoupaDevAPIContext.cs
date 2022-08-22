using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Context
{
    public class PoupaDevAPIContext : DbContext
    {
        public PoupaDevAPIContext(DbContextOptions<PoupaDevAPIContext> options) : base(options){}

        public DbSet<ObjetivoFinanceiro> ObjetivosFinanceiros { get; set; }
        public DbSet<OperacaoFinanceira> OperacoesFinanceiras { get; set; }        
    }
}