using System;
using System.Collections.Generic;

namespace restaurante_comidas_tipicas_del_sur.Entity;

public partial class DetallexFactura
{
    public int IdDetallesxFactura { get; set; }

    public int? NroFactura { get; set; }

    public int? IdSupervisor { get; set; }

    public string? Plato { get; set; }

    public decimal? Valor { get; set; }

    public virtual Supervisor? IdSupervisorNavigation { get; set; }

    public virtual Factura? NroFacturaNavigation { get; set; }
}
