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
    public class TurnoService : ITurnoService
    {
        ITurnoRepository repository;
        public TurnoService(ITurnoRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<TurnoDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<TurnoDTO, TTurno>(repository.Items);
        }

        public async Task Insert(TurnoDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TTurno, TurnoDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(TurnoDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TTurno, TurnoDTO>(entityDTO);
            await repository.Save(entity);
        }
    }
}
