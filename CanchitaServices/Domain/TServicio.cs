using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TServicio
    {
        public TServicio()
        {
            TLocalServicio = new HashSet<TLocalServicio>();
        }

        public Guid ServId { get; set; }
        public string ServNombre { get; set; }

        public ICollection<TLocalServicio> TLocalServicio { get; set; }
    }
}
