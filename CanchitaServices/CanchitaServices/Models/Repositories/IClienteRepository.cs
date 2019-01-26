using CanchitaServices.Models.Repositories;
using Domain;
using System;
using System.Linq;

namespace CanchitaServices.Models.Repositories
{
    public interface IClienteRepository : IRepository<TCliente>
    {
        //Quitamos estos metodos ya que ya están definidas en IRepository
        /*IQueryable<TCliente> Clientes { get; }
        void SaveClient(TCliente cliente);
        TCliente DeleteCliente(Guid ClienteID);*/
    }
}
