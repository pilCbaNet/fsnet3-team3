using System;
using System.Collections.Generic;

namespace MiBilleteraWebApi.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Localidades = new HashSet<Localidad>();
        }

        public int IdProvincia { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual ICollection<Localidad> Localidades { get; set; }
    }
}
