using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ILocalServicioService
    {
        Task Insert(LocalServicioDTO entityDTO);
        IList<LocalServicioDTO> GetAll();
        Task Update(LocalServicioDTO entityDTO);
        void Delete(Guid entityId);
    }
}
