using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;
using restaurante_comidas_tipicas_del_sur.Repository;

namespace restaurante_comidas_tipicas_del_sur.Service.Impl
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepo;
        private readonly IDetalleFacturaRepository _detalleRepo;

        public FacturaService(IFacturaRepository facturaRepo, IDetalleFacturaRepository detalleRepo)
        {
            _facturaRepo = facturaRepo;
            _detalleRepo = detalleRepo;
        }

        public async Task CrearFacturaAsync(FacturaRequest request)
        {
            var factura = new Factura
            {
                IdCliente = request.IdCliente,
                IdMesero = request.IdMesero,
                NroMesa = request.NroMesa,
                Fecha = request.Fecha
            };
            await _facturaRepo.crearFactura(factura);
            foreach (var det in request.Detalles)
            {
                var detalle = new DetallexFactura
                {
                    NroFactura = factura.NroFactura,
                    IdSupervisor = det.IdSupervisor,
                    Plato = det.Plato,
                    Valor = det.Valor
                };
                
            }
        }
    }
}
