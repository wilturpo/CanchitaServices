using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TProvincia
    {
        public TProvincia()
        {
            TDistrito = new HashSet<TDistrito>();
        }

        public Guid ProvId { get; set; }
        public string ProvNombre { get; set; }
        public Guid DtoId { get; set; }

        public TDepartamento Dto { get; set; }
        public ICollection<TDistrito> TDistrito { get; set; }
    }
}
