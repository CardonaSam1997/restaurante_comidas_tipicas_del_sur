using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;
using restaurante_comidas_tipicas_del_sur.Repository;

namespace restaurante_comidas_tipicas_del_sur.Service.Impl
{
    public class FacturaService : IFacturaService
    {
        private readonly IMeseroRepository _meseroRepo;
        private readonly IFacturaRepository _facturaRepo;        
        private readonly IClienteRepository _clienteRepo;
        private readonly IMesaRepository _mesaRepo;
        private readonly IDetalleFacturaRepository _detalleFacturaRepository;


        public FacturaService(IFacturaRepository facturaRepo,IMeseroRepository meseroRepo, IClienteRepository clienteRepo,
                              IMesaRepository mesaRepo, IDetalleFacturaRepository detalleFacturaRepository)
        {
            _facturaRepo = facturaRepo;            
            _meseroRepo = meseroRepo;
            _clienteRepo = clienteRepo;
            _mesaRepo = mesaRepo;
            _detalleFacturaRepository = detalleFacturaRepository;
        }

        public async Task<int> CrearFacturaAsync(CrearFacturaRequest dto)
        {            
            var cliente = await _clienteRepo.obtenerClientePorId(dto.Cliente.Identificacion);

            if (cliente == null)
            {
                cliente = new Cliente
                {
                    Identificacion = dto.Cliente.Identificacion,
                    Nombres = dto.Cliente.Nombres,
                    Apellidos = dto.Cliente.Apellidos,
                    Direccion = dto.Cliente.Direccion,
                    Telefono = dto.Cliente.Telefono
                };
                await _clienteRepo.agregarCliente(cliente); 
            }

            
            var mesero = await _meseroRepo.obtenerMeseroPorId(dto.Mesero.IdMesero);

            if (mesero == null)
            {
                mesero = new Mesero
                {
                    Nombres = dto.Mesero.Nombres
                };
                await _meseroRepo.agregarMesero(mesero);
            }
            
            var mesa = await _mesaRepo.obtenerMesaPorId(dto.Mesa.NroMesa);
            if (mesa == null)
            {
                mesa = new Mesa
                {
                    Nombre = dto.Mesa.Nombre
                };
                await _mesaRepo.agregarMesa(mesa);
            }

            var factura = new Factura
            {
                IdCliente = cliente.Identificacion,
                IdMesero = mesero.IdMesero,
                NroMesa = mesa.NroMesa,
                Fecha = DateOnly.FromDateTime(DateTime.UtcNow)
            };

            await _facturaRepo.crearFactura(factura);

            foreach (var plato in dto.Platos)
            {
                var detalle = new DetallexFactura
                {
                    IdSupervisor = 1,
                    Plato = plato.Plato,
                    Valor = plato.Valor,
                    NroFactura = factura.NroFactura
                };

                await _detalleFacturaRepository.agregarDetalleFactura(detalle);
            }

            return factura.NroFactura;
        }
    }

}
