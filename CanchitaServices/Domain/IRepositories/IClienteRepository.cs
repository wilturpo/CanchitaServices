//using CanchitaServices.Models.Repositories;
using Domain;
using System;
using System.Linq;

namespace Domain.IRepositories
{
    public interface IClienteRepository : IRepository<TCliente>
    {
        //Quitamos estos metodos ya que ya están definidas en IRepository
        /*IQueryable<TCliente> Clientes { get; }
        void SaveClient(TCliente cliente);
        TCliente DeleteCliente(Guid ClienteID);*/
    }
}
