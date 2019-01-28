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
    public class LocalServicioService : ILocalServicioService
    {
        ILocalServicioRepository repository;
        public LocalServicioService(ILocalServicioRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<LocalServicioDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<LocalServicioDTO, TLocalServicio>(repository.Items);
        }

        public async Task Insert(LocalServicioDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TLocalServicio, LocalServicioDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(LocalServicioDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TLocalServicio, LocalServicioDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
