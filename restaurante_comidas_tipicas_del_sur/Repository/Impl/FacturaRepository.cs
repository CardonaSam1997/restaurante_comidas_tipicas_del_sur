using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository.Impl
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly RestauranteComidasDelSurContext _context;
        
        public FacturaRepository(RestauranteComidasDelSurContext context)
        {
            _context = context;
        }
        public async Task crearFactura(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }
       
        
    }
    
    
}
