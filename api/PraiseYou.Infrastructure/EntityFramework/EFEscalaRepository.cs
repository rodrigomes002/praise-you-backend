﻿using Microsoft.EntityFrameworkCore;
using PraiseYou.Domain.Escalas;
using PraiseYou.Domain.Escalas.Interface;
using System.Collections.Generic;
using System.Linq;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFEscalaRepository : EscalaRepository
    {
        private readonly ApplicationContext context;

        public EFEscalaRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Escala> ListarTodos()
        {
            var dados = this.context.Escala   
               .Include(m=> m.Musicos)
               .Include(m => m.Musicas)
               .ToList();

            return dados;
        }

        public Escala ListarPorId(int id)
        {
            return this.context.Escala
                .Include(m => m.Musicos)
                .Include(m => m.Musicas)
                .Where(e => e.Id == id).FirstOrDefault();
        }

        public void Cadastrar(Escala escala)
        {
            this.context.Escala.Add(escala);
        }

        public void Deletar(Escala escala)
        {
            this.context.Escala.Remove(escala);
        }
    }
}
