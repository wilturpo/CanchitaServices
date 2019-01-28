using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IImagenService
    {
        Task Insert(ImagenDTO entityDTO);
        IList<ImagenDTO> GetAll();
        Task Update(ImagenDTO entityDTO);
        void Delete(Guid entityId);
    }
}
