using Domain;
using Domain.IRepositories;
using Infraestructure.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class EFProvinciaRepository : IProvinciaRepository
    {
        public IQueryable<TProvincia> Items => context.TProvincia;
        private CanchitaDbContext context;

        public EFProvinciaRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TProvincia provincia)
        {
            if (provincia.ProvId == Guid.Empty)
            {
                provincia.ProvId = Guid.NewGuid();
                context.TProvincia.Add(provincia);
            }
            else
            {
                TProvincia dbEntry = context.TProvincia
                .FirstOrDefault(p => p.ProvId == provincia.ProvId);
                if (dbEntry != null)
                {
                    dbEntry.ProvNombre = provincia.ProvNombre;
                    //AQUIIII
                    dbEntry.DtoId = provincia.DtoId;
                }
            }
            await context.SaveChangesAsync();
        }
        public void Delete(Guid ProvinciaId)
        {
            TProvincia dbEntry = context.TProvincia
            .FirstOrDefault(p => p.ProvId == ProvinciaId);
            if (dbEntry != null)
            {
                context.TProvincia.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
