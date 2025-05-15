using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente?> obtenerClientePorId(int id);
        Task<IEnumerable<Cliente>> obtenerClientesAsync();
        Task agregarCliente(Cliente cliente);

        Task<List<Cliente>> obtenerClientesPorConsumo(decimal valorMinimo);
    }
}
