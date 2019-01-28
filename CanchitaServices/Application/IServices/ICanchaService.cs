using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICanchaService
    {
        Task Insert(CanchaDTO entityDTO);
        IList<CanchaDTO> GetAll();
        Task Update(CanchaDTO entityDTO);
        void Delete(Guid entityId);
    }
}
