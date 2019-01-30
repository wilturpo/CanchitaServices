using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public class EFCanchaRepository : ICanchaRepository
    {
        public IQueryable<TCancha> Items => context.TCancha;
        private CanchitaDbContext context;

        public EFCanchaRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TCancha cancha)
        {
            if (cancha.CanchaId == Guid.Empty)
            {
                cancha.CanchaId = Guid.NewGuid();
                context.TCancha.Add(cancha);
            }
            else
            {
                TCancha dbEntry = context.TCancha
                .FirstOrDefault(p => p.CanchaId == cancha.CanchaId);
                if (dbEntry != null)
                {
                    dbEntry.CanchaTipo = cancha.CanchaTipo;
                    dbEntry.CanchaDescripcion = cancha.CanchaDescripcion;
                    dbEntry.LocalId = cancha.LocalId;
                }
            }

            await context.SaveChangesAsync();
        }
        public void Delete(Guid CanchaId)
        {
            TCancha dbEntry = context.TCancha
            .FirstOrDefault(p => p.CanchaId == CanchaId);
            if (dbEntry != null)
            {
                context.TCancha.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
