using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ClienteDTO
    {
        public Guid CliId { get; set; }
        public string CliNombres { get; set; }
        public string CliApellidos { get; set; }
        public string CliEmail { get; set; }
        public string CliTelefono { get; set; }
    }
}
