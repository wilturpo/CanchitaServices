using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public class EFAlquilerRepository : IAlquilerRepository
    {
        public IQueryable<TAlquiler> Items => context.TAlquiler;
        private CanchitaDbContext context;

        public EFAlquilerRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TAlquiler alquiler)
        {
            if (alquiler.AlquiId == Guid.Empty)
            {
                alquiler.AlquiId = Guid.NewGuid();
                context.TAlquiler.Add(alquiler);
            }
            else
            {
                TAlquiler dbEntry = context.TAlquiler
                .FirstOrDefault(p => p.AlquiId == alquiler.AlquiId);
                if (dbEntry != null)
                {
                    dbEntry.AlquiAdelanto = alquiler.AlquiAdelanto;
                    dbEntry.AlquiAdelanto = alquiler.AlquiAdelanto;
                    dbEntry.AlquiCancelado = alquiler.AlquiCancelado;
                    dbEntry.AlquiFechaReserva = alquiler.AlquiFechaReserva;
                    dbEntry.AlquiHoraInicio = alquiler.AlquiHoraInicio;
                    dbEntry.AlquiHoraFin = alquiler.AlquiHoraFin;
                    dbEntry.AlquiPagoReal = alquiler.AlquiPagoReal;
                    dbEntry.AlquiEstado = alquiler.AlquiEstado;
                    dbEntry.CliId = alquiler.CliId;
                    dbEntry.CanchaId = alquiler.CanchaId;
                }
            }

            await context.SaveChangesAsync();
        }
        public void Delete(Guid AlquilerId)
        {
            TAlquiler dbEntry = context.TAlquiler
            .FirstOrDefault(p => p.AlquiId == AlquilerId);
            if (dbEntry != null)
            {
                context.TAlquiler.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
