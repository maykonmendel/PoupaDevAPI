using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoupaDevAPI.Context;
using PoupaDevAPI.Exceptions;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Repositories
{
    public class ContaObjetivoRepository : IRepositoryBase<ContaObjetivo, int>
    {
        private readonly PoupaDevAPIContext _context;

        public ContaObjetivoRepository(PoupaDevAPIContext context) 
        {
            _context = context;
        }

        public async Task<ContaObjetivo> Create(ContaObjetivo contaObjetivo)
        {
            var conta = _context.ContasObjetivos.Add(contaObjetivo);

            if (conta.State != EntityState.Added)
            {
                throw new BadRequestException("Erro ao cadastrar uma nova Conta. Tente novamente.");
            }

            await _context.SaveChangesAsync();

            return contaObjetivo;
        }

        public async Task<ContaObjetivo> Update(ContaObjetivo contaObjetivo, int id)
        {
            contaObjetivo = _context.ContasObjetivos.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (contaObjetivo == null)
            {
                throw new BadRequestException("Conta não cadastrada!");
            }            

            _context.Entry(contaObjetivo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return contaObjetivo;
        }

        public async Task Delete(int id)
        {
            var contaObjetivo = await _context.ContasObjetivos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (contaObjetivo == null)
            {
                throw new BadRequestException("Conta não cadastrada!");
            }

            if (contaObjetivo.EstaDeletado != true)
            {
                contaObjetivo.EstaDeletado = true;
                _context.Entry(contaObjetivo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ContaObjetivo>> GetDeleted()
        {
            var listaContasDesativadas = _context.ContasObjetivos.Where(x => x.EstaDeletado == true).ToListAsync();

            if(listaContasDesativadas == null) 
            {
                throw new NotFoundException("Não há resultado a ser exibido!");
            }

            return await listaContasDesativadas;
        }

        public async Task<List<ContaObjetivo>> GetAll()
        {
            var listaContas = _context.ContasObjetivos.AsNoTracking().ToListAsync();

            if (listaContas == null)
            {
                throw new NotFoundException("Não há resultado a ser exibido!");
            }

            return await listaContas;
        }

        public async Task<ContaObjetivo> GetById(int id)
        {
            var contaObjetivo = _context.ContasObjetivos.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);

            if (contaObjetivo == null)
            {
                throw new NotFoundException("Conta não cadastrada!");
            }

            return await contaObjetivo;
        }
    }
}