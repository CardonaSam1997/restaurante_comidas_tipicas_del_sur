﻿using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Entity;


namespace restaurante_comidas_tipicas_del_sur.Repository.Impl
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly RestauranteComidasDelSurContext _context;

        public ClienteRepository(RestauranteComidasDelSurContext context)
        {
            _context = context;
        }

        public async Task<Cliente?> obtenerClientePorId(int id) =>
        await _context.Clientes.FindAsync(id);

        public async Task<IEnumerable<Cliente>> obtenerClientesAsync() =>
        await _context.Clientes.ToListAsync();
        

        public async Task agregarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Cliente>> obtenerClientesPorConsumo(decimal valorMinimo)
        {
            var clientes = await _context.Clientes
                .Where(c => c.Facturas
                    .SelectMany(f => f.DetallexFacturas)
                    .Sum(d => d.Valor) >= valorMinimo)
                .ToListAsync();

            return clientes;
        }
    }
}
