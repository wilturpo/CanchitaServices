using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TLocalServicio
    {
        public TLocalServicio()
        {
            TImagen = new HashSet<TImagen>();
        }

        public Guid LocServId { get; set; }
        public Guid LocalId { get; set; }
        public Guid ServId { get; set; }

        public TLocal Local { get; set; }
        public TServicio Serv { get; set; }
        public ICollection<TImagen> TImagen { get; set; }
    }
}
