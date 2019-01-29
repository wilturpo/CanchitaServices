using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITurnoService
    {
        Task Insert(TurnoDTO entityDTO);
        IList<TurnoDTO> GetAll();
        Task Update(TurnoDTO entityDTO);
        void Delete(Guid entityId);
    }
}
