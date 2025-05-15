using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository.Impl
{
    public class DetalleFacturaRepository: IDetalleFacturaRepository
    {
        private readonly RestauranteComidaTipicaDelSurContext _context;

        public DetalleFacturaRepository(RestauranteComidaTipicaDelSurContext context)
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
        {  // Consulta a la base de datos
            var resultado = await _context.DetallexFacturas
                .Where(d => d.NroFacturaNavigation.Fecha.HasValue &&
                            d.NroFacturaNavigation.Fecha.Value.Year == anio &&
                            d.NroFacturaNavigation.Fecha.Value.Month == mes)
                .GroupBy(d => d.Plato)
                .Select(g => new
                {
                    Plato = g.Key,
                    TotalVendido = g.Count(),
                    TotalFacturado = g.Sum(d => d.Valor)  // Usamos Valor, ya que es el campo que tiene el monto de la venta
                })
                .OrderByDescending(g => g.TotalVendido)
                .FirstOrDefaultAsync();

            // Verificamos si hay resultados y devolvemos el DTO
            if (resultado != null)
            {
                return new PlatoMasVendidoDto
                {
                    Plato = resultado.Plato,
                    CantidadVendida = resultado.TotalVendido,
                    TotalFacturado = resultado.TotalFacturado
                };
            }

            return null;
        }
    }
}
