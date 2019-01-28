using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAlquilerService
    {
        Task Insert(AlquilerDTO entityDTO);
        IList<AlquilerDTO> GetAll();
        Task Update(AlquilerDTO entityDTO);
        void Delete(Guid entityId);
    }
}
