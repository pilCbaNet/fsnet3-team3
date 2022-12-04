using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Operacion
    {
        public int IdOperacion { get; set; }
        public bool EsDeposito { get; set; }
        public DateTime? Fecha { get; set; }
        public int Monto { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdCuenta { get; set; }

        public virtual Cuenta? IdCuentaNavigation { get; set; }
    }
}
