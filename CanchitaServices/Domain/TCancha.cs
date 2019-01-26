using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TCancha
    {
        public TCancha()
        {
            TAlquiler = new HashSet<TAlquiler>();
            TImagen = new HashSet<TImagen>();
            TPrecio = new HashSet<TPrecio>();
        }

        public Guid CanchaId { get; set; }
        public string CanchaTipo { get; set; }
        public string CanchaDescripcion { get; set; }
        public Guid LocalId { get; set; }

        public TLocal Local { get; set; }
        public ICollection<TAlquiler> TAlquiler { get; set; }
        public ICollection<TImagen> TImagen { get; set; }
        public ICollection<TPrecio> TPrecio { get; set; }
    }
}
