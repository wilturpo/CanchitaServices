using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TImagen
    {
        public Guid ImaId { get; set; }
        public string ImaUrl { get; set; }
        public Guid CanchaId { get; set; }
        public Guid LocalId { get; set; }
        public Guid LocServId { get; set; }

        public TCancha Cancha { get; set; }
        public TLocalServicio LocServ { get; set; }
        public TLocal Local { get; set; }
    }
}
