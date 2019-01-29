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
    public class PrecioService : IPrecioService
    {
        IPrecioRepository repository;
        public PrecioService(IPrecioRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<PrecioDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<PrecioDTO, TPrecio>(repository.Items);
        }

        public async Task Insert(PrecioDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TPrecio, PrecioDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(PrecioDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TPrecio, PrecioDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
