using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IDistritoService
    {
        Task Insert(DistritoDTO entityDTO);
        IList<DistritoDTO> GetAll();
        Task Update(DistritoDTO entityDTO);
        void Delete(Guid entityId);
    }
}
