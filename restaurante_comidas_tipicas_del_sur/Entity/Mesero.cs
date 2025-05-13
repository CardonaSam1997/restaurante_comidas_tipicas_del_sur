using System;
using System.Collections.Generic;

namespace restaurante_comidas_tipicas_del_sur.Entity;

public partial class Mesero
{
    public int IdMesero { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public int? Edad { get; set; }

    public int? Antiguedad { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
