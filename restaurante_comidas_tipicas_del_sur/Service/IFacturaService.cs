using restaurante_comidas_tipicas_del_sur.Dto;

namespace restaurante_comidas_tipicas_del_sur.Service
{
    public interface IFacturaService
    {
        Task<int> CrearFacturaAsync(CrearFacturaDto dto);

    }
}
