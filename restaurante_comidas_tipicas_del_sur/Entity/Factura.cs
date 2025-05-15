using System;
using System.Collections.Generic;

namespace restaurante_comidas_tipicas_del_sur.Entity;

public partial class Factura
{
    public int NroFactura { get; set; }

    public int? IdCliente { get; set; }

    public int? NroMesa { get; set; }

    public int? IdMesero { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual ICollection<DetallexFactura> DetallexFacturas { get; set; } = new List<DetallexFactura>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Mesero? IdMeseroNavigation { get; set; }

    public virtual Mesa? NroMesaNavigation { get; set; }
}
