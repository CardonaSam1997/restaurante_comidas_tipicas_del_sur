using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository
{
    public interface IMesaRepository
    {
        Task<Mesa> obtenerMesaPorId(int nroMesa);
        Task<IEnumerable<Mesa>> obtenerMesas();
        Task agregarMesa(Mesa mesa);

    }
}
