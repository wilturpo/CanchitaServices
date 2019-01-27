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
    public class DepartamentoService : IDepartamentoServices
    {
        IDepartamentoRepository repository;
        public DepartamentoService(IDepartamentoRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<DepartamentoDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<DepartamentoDTO, TDepartamento>(repository.Items);
        }

        public async Task Insert(DepartamentoDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TDepartamento, DepartamentoDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(DepartamentoDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TDepartamento, DepartamentoDTO>(entityDTO);
            await repository.Save(entity);
        }

    }
}
