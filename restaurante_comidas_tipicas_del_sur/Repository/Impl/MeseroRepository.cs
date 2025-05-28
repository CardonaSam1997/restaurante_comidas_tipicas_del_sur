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

        public List<MeseroVentasDto> ObtenerVentasPorMesero(DateOnly fecha)
        {
            var resultado = _context.Facturas
            .Include(f => f.IdMeseroNavigation)
            .Include(f => f.DetallexFacturas)
            .SelectMany(f => f.DetallexFacturas.Select(df => new
            {                
                Nombre = f.IdMeseroNavigation.Nombres,
                Apellido = f.IdMeseroNavigation.Apellidos,
                Valor = df.Valor ?? 0
            }))
            .GroupBy(x => new {  x.Nombre, x.Apellido })
            .Select(g => new MeseroVentasDto
            {
                Nombre = g.Key.Nombre + " " + g.Key.Apellido,                
                TotalVendido = g.Sum(x => x.Valor)
            })
            .ToList();
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
