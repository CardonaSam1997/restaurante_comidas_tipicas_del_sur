using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository
{
    public interface ISupervisorRepository
    {
        Task<Supervisor> obtenerSupervisorPorId(int id);
        Task<IEnumerable<Supervisor>> ObtenerSupervisores();
    }
}
