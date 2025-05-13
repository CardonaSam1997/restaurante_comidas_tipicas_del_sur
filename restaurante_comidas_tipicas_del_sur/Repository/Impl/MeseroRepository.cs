using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository.Impl
{
    public class MeseroRepository: IMeseroRepository
    {

        private readonly RestauranteComidaTipicaDelSurContext _context;

        public MeseroRepository(RestauranteComidaTipicaDelSurContext context)
        {
            _context = context;
        }

        async public Task<Mesero?> obtenerMeseroPorId(int id) =>
        await _context.Meseros.FindAsync(id);

        async public Task<IEnumerable<Mesero>> obtenerMeserosAsync() =>
        await _context.Meseros.ToListAsync();

        async public Task agregarMesero(Mesero mesero)
        {
            _context.Meseros.Add(mesero);
            await _context.SaveChangesAsync();
        }
    }
}
