using System;
using System.Collections.Generic;

namespace restaurante_comidas_tipicas_del_sur.Entity;

public partial class Cliente
{
    public int Identificacion { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
