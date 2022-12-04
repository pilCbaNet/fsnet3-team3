
using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Operacion = new HashSet<Operacion>();
        }

        public int IdCuenta { get; set; }
        public int Cvu { get; set; }
        public int Saldo { get; set; }
        public bool EstaHabilitada { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdCliente { get; set; }
        public int? IdMoneda { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Moneda? IdMonedaNavigation { get; set; }
        public virtual ICollection<Operacion> Operacion { get; set; }
    }
}
