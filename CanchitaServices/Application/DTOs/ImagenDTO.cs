using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ImagenDTO
    {
        public Guid ImaId { get; set; }
        public string ImaUrl { get; set; }
        public Guid CanchaId { get; set; }
        public Guid LocalId { get; set; }
        public Guid LocServId { get; set; }
    }
}
