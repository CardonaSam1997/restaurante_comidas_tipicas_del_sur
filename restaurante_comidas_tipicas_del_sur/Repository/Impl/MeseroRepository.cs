using Microsoft.EntityFrameworkCore;
using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Entity;
using System;

namespace restaurante_comidas_tipicas_del_sur.Repository.Impl
{
    public class MeseroRepository: IMeseroRepository
    {

        private readonly RestauranteComidasDelSurContext _context;

        public MeseroRepository(RestauranteComidasDelSurContext context)
        {
            _context = context;
        }

        public async Task<List<MeseroVentasDto>> ObtenerVentasPorMesero()
        {
            var resultado = await _context.Meseros
                .Select(m => new MeseroVentasDto
                {
                    Nombre = m.Nombres,
                    Apellido = m.Apellidos,
                    TotalVendido = m.Facturas
                        .SelectMany(f => f.DetallexFacturas)
                        .Sum(d => (decimal?)d.Valor) ?? 0
                })
                .ToListAsync();

            return resultado;
        }

        async public Task<Mesero?> obtenerMeseroPorId(int id) =>
        await _context.Meseros.FindAsync(id);

        async public Task<IEnumerable<Mesero>> obtenerMeserosAsync() =>
        await _context.Meseros.ToListAsync();

        async public Task agregarMesero(Mesero mesero)
        {
            _context.Meseros.Add(mesero);
            await _context.SaveChangesAsync();
        }
    }
}
