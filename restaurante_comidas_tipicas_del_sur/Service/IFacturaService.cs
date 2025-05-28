using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Service
{
    public interface IFacturaService
    {
        Task<int> CrearFacturaAsync(CrearFacturaRequest request);

        Task<List<Factura>> ObtenerFacturas();

    }
}
