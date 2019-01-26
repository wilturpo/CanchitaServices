using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TDistrito
    {
        public TDistrito()
        {
            TLocal = new HashSet<TLocal>();
        }

        public Guid DistId { get; set; }
        public string DistDescripcion { get; set; }
        public Guid ProvId { get; set; }

        public TProvincia Prov { get; set; }
        public ICollection<TLocal> TLocal { get; set; }
    }
}
