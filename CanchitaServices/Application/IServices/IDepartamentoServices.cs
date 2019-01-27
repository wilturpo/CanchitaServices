using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IDepartamentoServices
    {
        Task Insert(DepartamentoDTO entityDTO);
        IList<DepartamentoDTO> GetAll();
        Task Update(DepartamentoDTO entityDTO);
        void Delete(Guid entityId);
    }
}
