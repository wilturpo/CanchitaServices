using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        IClienteRepository repository;
        public ClienteService(IClienteRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<ClienteDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO < ClienteDTO, TCliente>(repository.Items);
        }

        public async Task Insert(ClienteDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TCliente, ClienteDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(ClienteDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TCliente, ClienteDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
