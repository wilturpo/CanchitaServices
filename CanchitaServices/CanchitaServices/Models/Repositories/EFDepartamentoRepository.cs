using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public class EFDepartamentoRepository :IDepartamentoRepository
    {
        public IQueryable<TDepartamento> Items => context.TDepartamento;
        private CanchitaDbContext context;

        public EFDepartamentoRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TDepartamento departamento)
        {
            if (departamento.DptoId == Guid.Empty)
            {
                departamento.DptoId = Guid.NewGuid();
                context.TDepartamento.Add(departamento);
            }
            else
            {
                TDepartamento dbEntry = context.TDepartamento
                .FirstOrDefault(p => p.DptoId == departamento.DptoId);
                if (dbEntry != null)
                {
                    dbEntry.DtoNombre = departamento.DtoNombre;
                }
            }
            await context.SaveChangesAsync();
        }
        public void Delete(Guid DepartamentoId)
        {
            TDepartamento dbEntry = context.TDepartamento
            .FirstOrDefault(p => p.DptoId == DepartamentoId);
            if (dbEntry != null)
            {
                context.TDepartamento.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
