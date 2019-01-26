using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TAlquiler
    {
        public Guid AlquiId { get; set; }
        public decimal AlquiAdelanto { get; set; }
        public decimal AlquiCancelado { get; set; }
        public DateTime AlquiFechaReserva { get; set; }
        public TimeSpan AlquiHoraInicio { get; set; }
        public TimeSpan AlquiHoraFin { get; set; }
        public decimal AlquiPagoReal { get; set; }
        public string AlquiEstado { get; set; }
        public Guid CliId { get; set; }
        public Guid CanchaId { get; set; }

        public TCancha Cancha { get; set; }
        public TCliente Cli { get; set; }
    }
}
