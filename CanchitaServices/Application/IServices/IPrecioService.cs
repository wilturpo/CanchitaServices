using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPrecioService
    {
        Task Insert(PrecioDTO entityDTO);
        IList<PrecioDTO> GetAll();
        Task Update(PrecioDTO entityDTO);
        void Delete(Guid entityId);
    }
}
