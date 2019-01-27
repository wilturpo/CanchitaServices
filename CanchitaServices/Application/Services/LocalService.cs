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
    public class LocalService : ILocalService
    {
        ILocalRepository repository;
        public LocalService(ILocalRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<LocalDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<LocalDTO, TLocal>(repository.Items);
        }

        public async Task Insert(LocalDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TLocal, LocalDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(LocalDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TLocal, LocalDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
