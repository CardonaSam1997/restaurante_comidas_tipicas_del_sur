using restaurante_comidas_tipicas_del_sur.Entity;

namespace restaurante_comidas_tipicas_del_sur.Repository
{
    public interface IFacturaRepository
    {
        Task crearFactura(Factura factura);
        Task<IEnumerable<Factura>> obtenerFacturaPorFechas(DateTime desde, DateTime hasta);
    }
}
