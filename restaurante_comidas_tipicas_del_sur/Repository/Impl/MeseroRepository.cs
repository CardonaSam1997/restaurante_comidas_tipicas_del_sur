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

      public async Task<List<MeseroVentasDto>> ObtenerVentasPorMesero(DateOnly fecha)
{
        var resultado = (from df in _context.DetallexFacturas
    join f in _context.Facturas on df.NroFactura equals f.NroFactura
    join m in _context.Meseros on f.NroFactura equals m.IdMesero
    where f.Fecha == fecha
    group df by m.Nombres into grupo
    select new MeseroVentasDto
    {
        Nombre = grupo.Key,    
        TotalVendido = grupo.Sum(x => x.Valor) ?? 0m
    }).ToList();

   
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
