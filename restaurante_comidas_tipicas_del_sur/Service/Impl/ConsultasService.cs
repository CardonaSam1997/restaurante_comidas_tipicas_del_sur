using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;
using restaurante_comidas_tipicas_del_sur.Repository;

namespace restaurante_comidas_tipicas_del_sur.Service.Impl
{
    public class ConsultasService : IConsultasService
    {
        private readonly IMeseroRepository _meseroRepo;
        private readonly IFacturaRepository _facturaRepo;
        private readonly IDetalleFacturaRepository _detalleRepo;
        private readonly IClienteRepository _clienteRepo;

        public ConsultasService(IMeseroRepository meseroRepo, IFacturaRepository facturaRepo, IDetalleFacturaRepository detalleRepo, IClienteRepository clienteRepo)
        {
            _meseroRepo = meseroRepo;
            _facturaRepo = facturaRepo;
            _detalleRepo = detalleRepo;
            _clienteRepo = clienteRepo;
        }

        public async Task<IEnumerable<MeseroVentasDto>> ObtenerVentasPorMeseroAsync(DateTime desde, DateTime hasta)
        {
            var facturas = await _facturaRepo.obtenerFacturaPorFechas(desde, hasta);
            var detalles = await _detalleRepo.obtenerDetallesFacturasAsync();
            var meseros = await _meseroRepo.obtenerMeserosAsync();

            return meseros.Select(m => new MeseroVentasDto
            {
                Nombre = m.Nombres,
                Apellido = m.Apellidos,
                TotalVendido = facturas.Where(f => f.IdMesero == m.IdMesero)
                                        .Sum(f => detalles.Where(d => d.NroFactura == f.NroFactura)
                                                          .Sum(d => d.Valor ?? 0))
            });
        }


        public async Task<IEnumerable<Cliente>> ObtenerClientesPorConsumo(decimal minimo)
        {
            var facturas = await _facturaRepo.obtenerFacturaPorFechas(DateTime.MinValue, DateTime.MaxValue);
            var detalles = await _detalleRepo.obtenerDetallesFacturasAsync();
            var clientes = await _clienteRepo.obtenerClientesAsync();

            return clientes.Where(c => facturas.Where(f => f.IdCliente == c.Identificacion)
                                               .Sum(f => detalles.Where(d => d.NroFactura == f.NroFactura).Sum(d => d.Valor)) >= minimo);
        }

        public async Task<PlatoMasVendidoDto?> ObtenerPlatoMasVendido(DateTime mes)
        {
            var facturas = await _facturaRepo.obtenerFacturaPorFechas(mes, mes.AddMonths(1));
            var detalles = await _detalleRepo.obtenerDetallesFacturasAsync();
            var platos = detalles.Where(d => facturas.Any(f => f.NroFactura == d.NroFactura))
                                 .GroupBy(d => d.Plato)
                                 .Select(g => new
                                 {
                                     Plato = g.Key,
                                     Cantidad = g.Count(),
                                     Total = g.Sum(x => x.Valor ?? 0)
                                 }).OrderByDescending(p => p.Cantidad).FirstOrDefault();
            if (platos == null || platos.Plato == null)
                return null;
            return new PlatoMasVendidoDto
            {
                Plato = platos.Plato,
                CantidadVendida = platos.Cantidad,
                TotalFacturado = platos.Total
            };
        }
    }
}
