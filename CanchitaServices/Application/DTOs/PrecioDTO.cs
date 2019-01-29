using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class PrecioDTO
    {
        public Guid PrecId { get; set; }
        public decimal PrecMonto { get; set; }
        public Guid CanchaId { get; set; }
        public Guid TurnoId { get; set; }
    }
}
