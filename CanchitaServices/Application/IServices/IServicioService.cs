using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IServicioService
    {
        Task Insert(ServicioDTO entityDTO);
        IList<ServicioDTO> GetAll();
        Task Update(ServicioDTO entityDTO);
        void Delete(Guid entityId);
    }
}
