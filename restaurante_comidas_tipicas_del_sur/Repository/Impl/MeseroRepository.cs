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

        public async Task<List<MeseroVentasDto>> ObtenerVentasPorMesero(DateOnly fecha){
            var query = from mesero in _context.Meseros
                        join factura in _context.Facturas on mesero.IdMesero equals factura.IdMesero into facturasGroup
                        from factura in facturasGroup.DefaultIfEmpty()
                        where factura == null || factura.Fecha == null || factura.Fecha == fecha
                        select new
                        {
                            Mesero = mesero,
                            Factura = factura
                        };

            var resultado = await query
                .GroupBy(x => new { x.Mesero.IdMesero, x.Mesero.Nombres, x.Mesero.Apellidos })
                .Select(g => new MeseroVentasDto
                {            
                    Nombre = $"{g.Key.Nombres} {g.Key.Apellidos}".Trim(),
                    TotalVendido = g
                        .Where(x => x.Factura != null)
                        .SelectMany(x => x.Factura.DetallexFacturas)
                        .Sum(df => df.Valor ?? 0m)
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
