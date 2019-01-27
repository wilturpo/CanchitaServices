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
    public class ProvinciaService : IProvinciaService
    {
        IProvinciaRepository repository;
        public ProvinciaService(IProvinciaRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<ProvinciaDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<ProvinciaDTO, TProvincia>(repository.Items);
        }

        public async Task Insert(ProvinciaDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TProvincia, ProvinciaDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(ProvinciaDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TProvincia, ProvinciaDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
