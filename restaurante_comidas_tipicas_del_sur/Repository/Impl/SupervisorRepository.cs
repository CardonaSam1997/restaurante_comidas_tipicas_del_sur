using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository.Impl
{
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly RestauranteComidasDelSurContext _context;

        public SupervisorRepository(RestauranteComidasDelSurContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Supervisor>> ObtenerSupervisores() =>
        await _context.Supervisors.ToListAsync();

        public async Task<Supervisor?> obtenerSupervisorPorId(int id) =>
        await _context.Supervisors.FindAsync(id);
    }
}
