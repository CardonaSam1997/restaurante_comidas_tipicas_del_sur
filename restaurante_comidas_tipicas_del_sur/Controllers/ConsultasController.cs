using Microsoft.AspNetCore.Mvc;
using restaurante_comidas_tipicas_del_sur.Service;

namespace restaurante_comidas_tipicas_del_sur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultasService _consultasService;

        public ConsultasController(IConsultasService consultasService)
        {
            _consultasService = consultasService;
        }

        [HttpGet("ventas-meseros")]
        public async Task<IActionResult> VentasPorMesero()
        {
            var resultado = await _consultasService.ObtenerVentasPorMesero();
            return Ok(resultado);
        }

        [HttpGet("clientes-por-consumo")]
        public async Task<IActionResult> ClientesPorConsumo([FromQuery] decimal valor)
        {
            var resultado = await _consultasService.ObtenerClientesPorConsumo(valor);
            return Ok(resultado);
        }

        [HttpGet("plato-mas-vendido")]
        public async Task<IActionResult> PlatoMasVendido(int anio,int mes)
        {
            var resultado = await _consultasService.ObtenerPlatoMasVendido(anio,mes);
            return Ok(resultado);
        }
    }
}
