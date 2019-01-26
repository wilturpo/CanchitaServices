using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public class EFClienteRepository : IClienteRepository
    {
        public IQueryable<TCliente> Items => context.TCliente;
        private CanchitaDbContext context;

        public EFClienteRepository(CanchitaDbContext ctx)
        {
            context = ctx;
        }
        public async Task Save(TCliente cliente)
        {
            if (cliente.CliId == Guid.Empty)
            {
                cliente.CliId = Guid.NewGuid();
                context.TCliente.Add(cliente);
            }
            else
            {
                TCliente dbEntry = context.TCliente
                .FirstOrDefault(p => p.CliId == cliente.CliId);
                if (dbEntry != null)
                {
                    dbEntry.CliNombres = cliente.CliNombres;
                    dbEntry.CliApellidos = cliente.CliApellidos;
                    dbEntry.CliTelefono = cliente.CliTelefono;
                    dbEntry.CliEmail = cliente.CliEmail;
                }
            }
           
        await context.SaveChangesAsync();
        }
        public void Delete(Guid ClienteID)
        {
            TCliente dbEntry = context.TCliente
            .FirstOrDefault(p => p.CliId == ClienteID);
            if (dbEntry != null)
            {
                context.TCliente.Remove(dbEntry);
                context.SaveChanges();
            }
            //return dbEntry;
        }
    }
}
