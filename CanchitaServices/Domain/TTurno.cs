using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TTurno
    {
        public TTurno()
        {
            TPrecio = new HashSet<TPrecio>();
        }

        public Guid TurnoId { get; set; }
        public string TurnoDescripcion { get; set; }
        public TimeSpan TurnoHorarioInicio { get; set; }
        public TimeSpan TurnoHorarioFin { get; set; }

        public ICollection<TPrecio> TPrecio { get; set; }
    }
}
