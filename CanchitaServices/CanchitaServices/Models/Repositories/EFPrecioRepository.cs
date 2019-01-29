using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public class EFPrecioRepository : IPrecioRepository
    {
        public IQueryable<TPrecio> Items => context.TPrecio;
        private CanchitaDbContext context;

        public EFPrecioRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TPrecio precio)
        {
            if (precio.PrecId == Guid.Empty)
            {
                precio.PrecId = Guid.NewGuid();
                context.TPrecio.Add(precio);
            }
            else
            {
                TPrecio dbEntry = context.TPrecio
                .FirstOrDefault(p => p.PrecId == precio.PrecId);
                if (dbEntry != null)
                {
                    dbEntry.PrecMonto = precio.PrecMonto;
                    dbEntry.CanchaId = precio.CanchaId;
                    dbEntry.TurnoId = precio.TurnoId;
                }
            }

            await context.SaveChangesAsync();
        }
        public void Delete(Guid PrecioId)
        {
            TPrecio dbEntry = context.TPrecio
            .FirstOrDefault(p => p.PrecId == PrecioId);
            if (dbEntry != null)
            {
                context.TPrecio.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
