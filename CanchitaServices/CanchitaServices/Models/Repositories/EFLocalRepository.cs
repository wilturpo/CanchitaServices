using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public class EFLocalRepository : ILocalRepository
    {
        public IQueryable<TLocal> Items => context.TLocal;
        private CanchitaDbContext context;

        public EFLocalRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TLocal local)
        {
            if (local.LocalId == Guid.Empty)
            {
                local.LocalId = Guid.NewGuid();
                context.TLocal.Add(local);
            }
            else
            {
                TLocal dbEntry = context.TLocal
                .FirstOrDefault(p => p.LocalId == local.LocalId);
                if (dbEntry != null)
                {
                    dbEntry.LocalDescripcion = local.LocalDescripcion;
                    dbEntry.LocalNombre = local.LocalNombre;
                    dbEntry.LocalDireccion = local.LocalDireccion;
                    dbEntry.LocalHoraApertura = local.LocalHoraApertura;
                    dbEntry.LocalHoraCierre = local.LocalHoraCierre;
                    dbEntry.LocalDist = local.LocalDist;
                    dbEntry.LocalTelefono = local.LocalTelefono;
                    dbEntry.LocalLatitud = local.LocalLatitud;
                    dbEntry.LocalLongitud = local.LocalLongitud;
                }
            }

            await context.SaveChangesAsync();
        }
        public void Delete(Guid LocalID)
        {
            TLocal dbEntry = context.TLocal
            .FirstOrDefault(p => p.LocalId == LocalID);
            if (dbEntry != null)
            {
                context.TLocal.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
