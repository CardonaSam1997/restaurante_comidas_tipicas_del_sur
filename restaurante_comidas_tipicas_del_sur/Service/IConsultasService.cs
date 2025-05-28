using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Service
{
    public interface IConsultasService
    {
        List<MeseroVentasDto> ObtenerVentasPorMesero(DateOnly fecha);       
       Task<List<Cliente>> ObtenerClientesPorConsumo(decimal valorMinimo);
       Task<PlatoMasVendidoDto> ObtenerPlatoMasVendido(int anio, int mes);

    }
}
