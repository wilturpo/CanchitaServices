using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class TurnoDTO
    {
        public Guid TurnoId { get; set; }
        public string TurnoDescripcion { get; set; }
        public TimeSpan TurnoHorarioInicio { get; set; }
        public TimeSpan TurnoHorarioFin { get; set; }
    }
}
