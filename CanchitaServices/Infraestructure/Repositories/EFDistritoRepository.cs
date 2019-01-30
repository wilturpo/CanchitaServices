using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class EFDistritoRepository : IDistritoRepository
    {
        public IQueryable<TDistrito> Items => context.TDistrito;
        private CanchitaDbContext context;

        public EFDistritoRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TDistrito distrito)
        {
            if (distrito.DistId == Guid.Empty)
            {
                distrito.DistId = Guid.NewGuid();
                context.TDistrito.Add(distrito);
            }
            else
            {
                TDistrito dbEntry = context.TDistrito
                .FirstOrDefault(p => p.DistId == distrito.DistId);
                if (dbEntry != null)
                {
                    dbEntry.DistDescripcion = distrito.DistDescripcion;
                    dbEntry.ProvId = distrito.ProvId;
                }
            }

            await context.SaveChangesAsync();
        }
        public void Delete(Guid DistritoId)
        {
            TDistrito dbEntry = context.TDistrito
            .FirstOrDefault(p => p.DistId == DistritoId);
            if (dbEntry != null)
            {
                context.TDistrito.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
