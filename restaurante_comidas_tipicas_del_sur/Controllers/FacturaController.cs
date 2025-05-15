using Microsoft.AspNetCore.Mvc;
using restaurante_comidas_tipicas_del_sur.Dto;
using restaurante_comidas_tipicas_del_sur.Service;

namespace restaurante_comidas_tipicas_del_sur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearFactura(CrearFacturaRequest request)
        {            
            await _facturaService.CrearFacturaAsync(request);            
            return Ok("Factura creada exitosamente");
        }
        /**
         * VERIFICAR LA TABLA CLIENTE EN LA BD EL CAMPO IDENTIFICACION NO PUEDE SER AUTOINCRMENT
         * CREO QUE LO MISMO ME PASA CON FACTURA
         */
    }
}
