﻿using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository
{
    public interface IDetalleFacturaRepository
    {
        Task<IEnumerable<DetallexFactura>> obtenerDetalleFacturasPorNumeroFactura(int nroFactura);
        Task<IEnumerable<DetallexFactura>> obtenerDetallesFacturasAsync();

        Task agregarDetalleFactura(DetallexFactura detalle);

        Task<PlatoMasVendidoDto> obtenerPlatoMasVendidoAsync(int anio, int mes);


    }
}
