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
    public class CanchaService : ICanchaService
    {
        ICanchaRepository repository;
        public CanchaService(ICanchaRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<CanchaDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<CanchaDTO, TCancha>(repository.Items);
        }

        public async Task Insert(CanchaDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TCancha, CanchaDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(CanchaDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TCancha, CanchaDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
