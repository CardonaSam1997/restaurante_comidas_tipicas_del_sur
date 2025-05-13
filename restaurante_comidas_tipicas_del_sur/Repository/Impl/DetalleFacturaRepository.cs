using Microsoft.EntityFrameworkCore;
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

    }
}
