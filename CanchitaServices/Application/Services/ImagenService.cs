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
    public class ImagenService : IImagenService
    {
        IImagenRepository repository;
        public ImagenService(IImagenRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<ImagenDTO> GetAll()
        {
            return
        Builders.GenericBuilder.builderListEntityDTO<ImagenDTO, TImagen>(repository.Items);
        }

        public async Task Insert(ImagenDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TImagen, ImagenDTO>(entityDTO);
            await repository.Save(entity);
        }

        public async Task Update(ImagenDTO entityDTO)
        {
            var entity =
        Builders.GenericBuilder.builderDTOEntity<TImagen, ImagenDTO> (entityDTO);
            await repository.Save(entity);
        }
    }
}
