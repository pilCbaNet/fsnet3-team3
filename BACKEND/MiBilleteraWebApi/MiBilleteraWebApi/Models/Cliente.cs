using System;
using System.Collections.Generic;

namespace MiBilleteraWebApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cuil { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Usuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdLocalidad { get; set; }

        public virtual Localidad? IdLocalidadNavigation { get; set; }
        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
