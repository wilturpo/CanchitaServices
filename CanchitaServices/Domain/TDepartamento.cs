using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TDepartamento
    {
        public TDepartamento()
        {
            TProvincia = new HashSet<TProvincia>();
        }

        public Guid DptoId { get; set; }
        public string DtoNombre { get; set; }

        public ICollection<TProvincia> TProvincia { get; set; }
    }
}
