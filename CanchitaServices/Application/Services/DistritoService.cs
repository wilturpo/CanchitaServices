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
    public class DistritoService : IDistritoService
    {
        IDistritoRepository repository;
        public DistritoService(IDistritoRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<DistritoDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<DistritoDTO, TDistrito>(repository.Items);
        }

        public async Task Insert(DistritoDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TDistrito, DistritoDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(DistritoDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TDistrito, DistritoDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
