using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository.Impl
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly RestauranteComidaTipicaDelSurContext _context;
        
        public FacturaRepository(RestauranteComidaTipicaDelSurContext context)
        {
            _context = context;
        }
        async public Task crearFactura(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }
        async public Task<IEnumerable<Factura>> obtenerFacturaPorFechas(DateTime desde, DateTime hasta) =>
            await _context.Facturas.Where(f => f.Fecha >= desde && f.Fecha <= hasta).ToListAsync();
        
    }
    
    
}
