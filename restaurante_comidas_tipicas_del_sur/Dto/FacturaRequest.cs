namespace restaurante_comidas_tipicas_del_sur.Dto
{
    public class FacturaRequest
    {
        public int IdCliente { get; set; }
        public int IdMesero { get; set; }
        public int NroMesa { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleFacturaRequest> Detalles { get; set; } = new();
    }
}
