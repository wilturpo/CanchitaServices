using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IClienteService
    {
        Task Insert(ClienteDTO entityDTO);
        IList<ClienteDTO> GetAll();
        Task Update(ClienteDTO entityDTO);
        void Delete(Guid entityId);
    }
}
