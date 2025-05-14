namespace restaurante_comidas_tipicas_del_sur.Dto
{
    public class CrearFacturaDto
    {
        public ClienteDto Cliente { get; set; }
        public MeseroDto Mesero { get; set; }
        public MesaDto Mesa { get; set; }
        public List<DetalleFacturaDto> Platos { get; set; }
    }
}
