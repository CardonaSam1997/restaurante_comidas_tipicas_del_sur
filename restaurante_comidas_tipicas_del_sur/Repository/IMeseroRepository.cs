using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository
{
    public interface IMeseroRepository
    {
        Task<Mesero?> obtenerMeseroPorId(int id);
        Task<IEnumerable<Mesero>> obtenerMeserosAsync();

        Task agregarMesero(Mesero mesero);

        Task<List<MeseroVentasDto>> ObtenerVentasPorMesero();
    }
}
