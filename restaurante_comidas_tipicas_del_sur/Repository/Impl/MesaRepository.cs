using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository.Impl
{
    public class MesaRepository: IMesaRepository
    {
        private readonly RestauranteComidasDelSurContext _context;

        public MesaRepository(RestauranteComidasDelSurContext context)
        {
            _context = context;
        }

        async public Task<Mesa?> obtenerMesaPorId(int nroMesa) =>
        await _context.Mesas.FindAsync(nroMesa);

        async public Task<IEnumerable<Mesa>> obtenerMesas() =>
        await _context.Mesas.ToListAsync();
        
        async public Task agregarMesa(Mesa mesa)
        {
            _context.Mesas.Add(mesa);
            await _context.SaveChangesAsync();
        }
    }
}
