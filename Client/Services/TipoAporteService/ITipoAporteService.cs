using Aportes.Shared.Models;

namespace Aportes.Client.Services.TiposAporteService
{
    public interface ITiposAportesService
    {
        List<TiposAportes> Tipos { get; set; }
        Task GetTiposAportes();
        Task<ServiceResponse<TiposAportes>> GetTiposAportes(int ID);
        Task<ServiceResponse<TiposAportes>> Eliminar(TiposAportes Tipo);
        Task<ServiceResponse<TiposAportes>> Guardar(TiposAportes Tipo);
    }
}
