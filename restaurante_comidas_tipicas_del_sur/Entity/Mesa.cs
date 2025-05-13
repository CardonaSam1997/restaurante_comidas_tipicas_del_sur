using System;
using System.Collections.Generic;

namespace restaurante_comidas_tipicas_del_sur.Entity;

public partial class Mesa
{
    public int NroMesa { get; set; }

    public string? Nombre { get; set; }

    public bool? Reservada { get; set; }

    public int? Puestos { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
