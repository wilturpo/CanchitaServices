using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public class EFImagenRepository : IImagenRepository
    {
        public IQueryable<TImagen> Items => context.TImagen;
        private CanchitaDbContext context;

        public EFImagenRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TImagen imagen)
        {
            if (imagen.ImaId == Guid.Empty)
            {
                imagen.ImaId = Guid.NewGuid();
                context.TImagen.Add(imagen);
            }
            else
            {
                TImagen dbEntry = context.TImagen
                .FirstOrDefault(p => p.ImaId == imagen.ImaId);
                if (dbEntry != null)
                {
                    dbEntry.ImaUrl = imagen.ImaUrl;
                    dbEntry.CanchaId = imagen.CanchaId;
                    dbEntry.LocalId = imagen.LocalId;
                    dbEntry.LocServId = imagen.LocServId;
                }
            }

            await context.SaveChangesAsync();
        }
        public void Delete(Guid ImagenId)
        {
            TImagen dbEntry = context.TImagen
            .FirstOrDefault(p => p.ImaId == ImagenId);
            if (dbEntry != null)
            {
                context.TImagen.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}




                    