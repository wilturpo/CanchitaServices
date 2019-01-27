using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class LocalDTO
    {
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
    }
}
