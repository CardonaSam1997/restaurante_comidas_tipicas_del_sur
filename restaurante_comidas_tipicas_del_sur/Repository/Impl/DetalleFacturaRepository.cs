using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository.Impl
{
    public class DetalleFacturaRepository: IDetalleFacturaRepository
    {
        private readonly RestauranteComidasDelSurContext _context;

        public DetalleFacturaRepository(RestauranteComidasDelSurContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DetallexFactura>> obtenerDetalleFacturasPorNumeroFactura(int nroFactura) =>
        await _context.DetallexFacturas.Where(d => d.NroFactura == nroFactura).ToListAsync();

        public async Task<IEnumerable<DetallexFactura>> obtenerDetallesFacturasAsync() =>
        await _context.DetallexFacturas.ToListAsync();

        public async Task agregarDetalleFactura(DetallexFactura detalle)
        {
            _context.DetallexFacturas.Add(detalle);
            await _context.SaveChangesAsync();
        }

        public async Task<PlatoMasVendidoDto> obtenerPlatoMasVendidoAsync(int anio, int mes)
        {
            var resultado = await _context.DetallexFacturas
                .Include(d => d.NroFacturaNavigation)
                .Where(d => d.NroFacturaNavigation != null &&
                            d.NroFacturaNavigation.Fecha.HasValue &&
                            d.NroFacturaNavigation.Fecha.Value.Year == anio &&
                            d.NroFacturaNavigation.Fecha.Value.Month == mes)
                .GroupBy(d => d.Plato)
                .Select(g => new
                {
                    Plato = g.Key,
                    CantidadVendida = g.Count(),
                    TotalFacturado = g.Sum(d => d.Valor)
                })
                .OrderByDescending(g => g.CantidadVendida)
                .FirstOrDefaultAsync();

            if (resultado == null)
            {
                return new PlatoMasVendidoDto { Plato = "N/A", CantidadVendida = 0, TotalFacturado = 0 };
            }

            var resul = await _context.DetallexFacturas
                .Where(x => x.Plato == resultado.Plato)
                .ToListAsync();

            return new PlatoMasVendidoDto
            {
                Plato = resultado.Plato ?? "N/A",
                CantidadVendida = resul.Count,
                TotalFacturado = resul.Sum(x=> x.Valor) ?? 0
            };
        }

    }
}
