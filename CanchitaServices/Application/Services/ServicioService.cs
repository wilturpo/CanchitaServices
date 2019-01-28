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
    public class ServicioService : IServicioService
    {
        IServicioRepository repository;
        public ServicioService(IServicioRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<ServicioDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<ServicioDTO, TServicio>(repository.Items);
        }

        public async Task Insert(ServicioDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TServicio, ServicioDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(ServicioDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TServicio, ServicioDTO>(entityDTO);
            await repository.Save(entity);
        }

    }
}
