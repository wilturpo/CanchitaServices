using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public class EFTurnoRepository : ITurnoRepository
    {
        public IQueryable<TTurno> Items => context.TTurno;
        private CanchitaDbContext context;
        public EFTurnoRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TTurno turno)
        {
            if (turno.TurnoId == Guid.Empty)
            {
                turno.TurnoId = Guid.NewGuid();
                context.TTurno.Add(turno);
            }
            else
            {
                TTurno dbEntry = context.TTurno
                .FirstOrDefault(p => p.TurnoId == turno.TurnoId);
                if (dbEntry != null)
                {
                    dbEntry.TurnoDescripcion = turno.TurnoDescripcion;
                    dbEntry.TurnoHorarioInicio = turno.TurnoHorarioInicio;
                    dbEntry.TurnoHorarioFin = turno.TurnoHorarioFin;
                }
            }

            await context.SaveChangesAsync();
        }
        public void Delete(Guid TurnoId)
        {
            TTurno dbEntry = context.TTurno
            .FirstOrDefault(p => p.TurnoId == TurnoId);
            if (dbEntry != null)
            {
                context.TTurno.Remove(dbEntry);
                context.SaveChangesAsync();
            }
        }
    }
}
