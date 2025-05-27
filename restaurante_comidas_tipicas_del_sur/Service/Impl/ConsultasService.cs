using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;
using restaurante_comidas_tipicas_del_sur.Repository;
using restaurante_comidas_tipicas_del_sur.Repository.Impl;

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

        public async Task<List<MeseroVentasDto>> ObtenerVentasPorMesero(DateOnly fecha)
        {
            return await _meseroRepo.ObtenerVentasPorMesero(fecha);
        }
        
        public async Task<List<Cliente>> ObtenerClientesPorConsumo(decimal valorMinimo)
        {
            return await _clienteRepo.obtenerClientesPorConsumo(valorMinimo);
        }

        public async Task<PlatoMasVendidoDto> ObtenerPlatoMasVendido(int anio,int mes)
        {
            return await _detalleRepo.obtenerPlatoMasVendidoAsync(anio, mes);
        }

    }
}
