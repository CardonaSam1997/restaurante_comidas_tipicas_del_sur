namespace restaurante_comidas_tipicas_del_sur.Dto
{
    public class DetalleFacturaDto
    {
        public int IdSupervisor { get; set; }
        public string Plato { get; set; }
        public decimal Valor { get; set; }
    }
}
