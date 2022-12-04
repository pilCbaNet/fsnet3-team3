using Entities;
using System;
using System.Collections.Generic;

namespace MEntities
{
    public partial class Localidad
    {
        public Localidad()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdLocalidad { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Provincia? IdProvinciaNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
