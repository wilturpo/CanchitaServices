using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class DistritoDTO
    {
        public Guid DistId { get; set; }
        public string DistDescripcion { get; set; }
        public Guid ProvId { get; set; }
    }
}
