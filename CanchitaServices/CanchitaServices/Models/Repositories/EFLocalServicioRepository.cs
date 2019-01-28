using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public class EFLocalServicioRepository : ILocalServicioRepository
    {
        public IQueryable<TLocalServicio> Items => context.TLocalServicio;
        private CanchitaDbContext context;

        public EFLocalServicioRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TLocalServicio localServicio)
        {
            if (localServicio.LocServId == Guid.Empty)
            {
                localServicio.LocServId = Guid.NewGuid();
                context.TLocalServicio.Add(localServicio);
            }
            else
            {
                TLocalServicio dbEntry = context.TLocalServicio
                .FirstOrDefault(p => p.LocalId == localServicio.LocalId);
                if (dbEntry != null)
                {
                    dbEntry.LocalId = localServicio.LocalId;
                    dbEntry.ServId = localServicio.ServId;

                }
            }

            await context.SaveChangesAsync();
        }
        public void Delete(Guid LocalServicioID)
        {
            TLocalServicio dbEntry = context.TLocalServicio
            .FirstOrDefault(p => p.LocalId == LocalServicioID);
            if (dbEntry != null)
            {
                context.TLocalServicio.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
