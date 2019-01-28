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
    public class AlquilerService : IAlquilerService
    {
        IAlquilerRepository repository;
        public AlquilerService(IAlquilerRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<AlquilerDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<AlquilerDTO, TAlquiler>(repository.Items);
        }

        public async Task Insert(AlquilerDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TAlquiler, AlquilerDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(AlquilerDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TAlquiler, AlquilerDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
