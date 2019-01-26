using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TPrecio
    {
        public Guid PrecId { get; set; }
        public decimal PrecMonto { get; set; }
        public Guid CanchaId { get; set; }
        public Guid TurnoId { get; set; }

        public TCancha Cancha { get; set; }
        public TTurno Turno { get; set; }
    }
}
