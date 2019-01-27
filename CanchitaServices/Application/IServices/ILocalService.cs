using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ILocalService
    {
        Task Insert(LocalDTO entityDTO);
        IList<LocalDTO> GetAll();
        Task Update(LocalDTO entityDTO);
        void Delete(Guid entityId);
    }
}
