using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TLocal
    {
        public TLocal()
        {
            TCancha = new HashSet<TCancha>();
            TImagen = new HashSet<TImagen>();
            TLocalServicio = new HashSet<TLocalServicio>();
        }

        public Guid LocalId { get; set; }
        public string LocalDescripcion { get; set; }
        public string LocalNombre { get; set; }
        public string LocalDireccion { get; set; }
        public TimeSpan LocalHoraApertura { get; set; }
        public TimeSpan LocalHoraCierre { get; set; }
        public string LocalTelefono { get; set; }
        public string LocalLatitud { get; set; }
        public string LocalLongitud { get; set; }
        public Guid LocalDist { get; set; }

        public TDistrito LocalDistNavigation { get; set; }
        public ICollection<TCancha> TCancha { get; set; }
        public ICollection<TImagen> TImagen { get; set; }
        public ICollection<TLocalServicio> TLocalServicio { get; set; }
    }
}
