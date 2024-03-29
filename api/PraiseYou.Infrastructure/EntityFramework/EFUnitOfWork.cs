﻿using PraiseYou.Domain;
using PraiseYou.Domain.Escalas.Interface;
using PraiseYou.Domain.Musicas.Interface;
using PraiseYou.Domain.Musicos.Interface;

namespace PraiseYou.Infrastructure.EntityFramework
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly ApplicationContext context;
        public EFUnitOfWork(ApplicationContext context)
        {
            this.context = context;
            this.MusicaRepository = new EFMusicaRepository(context);
            this.MusicoRepository = new EFMusicoRepository(context);
            this.EscalaRepository = new EFEscalaRepository(context);
            this.EscalaMusicaRepository = new EFEscalaMusicaRepository(context);
            this.EscalaMusicoRepository = new EFEscalaMusicoRepository(context);
        }
        public MusicaRepository MusicaRepository { get; }
        public MusicoRepository MusicoRepository { get; }
        public EscalaRepository EscalaRepository { get; }
        public EscalaMusicaRepository EscalaMusicaRepository { get; }
        public EscalaMusicoRepository EscalaMusicoRepository { get; }

        public void Commit()
        {
            this.context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
