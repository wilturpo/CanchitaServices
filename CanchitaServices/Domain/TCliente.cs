using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TCliente
    {
        public TCliente()
        {
            TAlquiler = new HashSet<TAlquiler>();
        }

        public Guid CliId { get; set; }
        public string CliNombres { get; set; }
        public string CliApellidos { get; set; }
        public string CliEmail { get; set; }
        public string CliTelefono { get; set; }

        public ICollection<TAlquiler> TAlquiler { get; set; }
    }
}
