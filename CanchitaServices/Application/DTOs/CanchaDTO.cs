using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class CanchaDTO
    {
        public Guid CanchaId { get; set; }
        public string CanchaTipo { get; set; }
        public string CanchaDescripcion { get; set; }
        public Guid LocalId { get; set; }
    }
}
