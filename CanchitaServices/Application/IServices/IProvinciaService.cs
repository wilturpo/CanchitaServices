using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IProvinciaService
    {
        Task Insert(ProvinciaDTO entityDTO);
        IList<ProvinciaDTO> GetAll();
        Task Update(ProvinciaDTO entityDTO);
        void Delete(Guid entityId);
    }
}
