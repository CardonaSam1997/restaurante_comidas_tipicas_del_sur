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
        private readonly RestauranteComidaTipicaDelSurContext _context;

        public FacturaService(IFacturaRepository facturaRepo,IMeseroRepository meseroRepo, IClienteRepository clienteRepo,
                              IMesaRepository mesaRepo, RestauranteComidaTipicaDelSurContext context)
        {
            _facturaRepo = facturaRepo;            
            _meseroRepo = meseroRepo;
            _clienteRepo = clienteRepo;
            _mesaRepo = mesaRepo;
            _context = context;
        }

        public async Task<int> CrearFacturaAsync(CrearFacturaDto dto)
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
                    IdMesero = dto.Mesero.IdMesero,
                    Nombres = dto.Mesero.Nombres
                };
                await _meseroRepo.agregarMesero(mesero);
            }
            
            var mesa = await _mesaRepo.obtenerMesaPorId(dto.Mesa.NroMesa);
            if (mesa == null)
            {
                mesa = new Mesa
                {
                    NroMesa = dto.Mesa.NroMesa,
                    Nombre = dto.Mesa.Nombre
                };
                await _mesaRepo.agregarMesa(mesa);
            }
            
            await _context.SaveChangesAsync();


            var factura = new Factura
            {
                IdCliente = cliente.Identificacion,
                IdMesero = mesero.IdMesero,
                NroMesa = mesa.NroMesa,
                Fecha = DateTime.UtcNow,
                DetallexFacturas = dto.Platos.Select(p => new DetallexFactura
                {
                    IdSupervisor = p.IdSupervisor,
                    Plato = p.Plato,
                    Valor = p.Valor
                }).ToList()
            };

            await _facturaRepo.crearFactura(factura);
            await _context.SaveChangesAsync();

            return factura.NroFactura;
        }
    }

}
