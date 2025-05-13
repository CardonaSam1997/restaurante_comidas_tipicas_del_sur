using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Service
{
    public interface IConsultasService
    {
        Task<IEnumerable<MeseroVentasDto>> ObtenerVentasPorMeseroAsync(DateTime desde, DateTime hasta);
        Task<IEnumerable<Cliente>> ObtenerClientesPorConsumo(decimal minimo);
        Task<PlatoMasVendidoDto> ObtenerPlatoMasVendido(DateTime mes);
    }
}
