using Aportes.Shared.Models;

namespace Aportes.Server.Services.AportTypeServices
{
    public interface IAportTypeServices
    {
        Task<ServiceResponse<TiposAportes>> GetTipoAporteAsync(int Id);
        Task<ServiceResponse<List<TiposAportes>>> GetAllTipoAporteAsync();
        Task<ServiceResponse<TiposAportes>> Guardar(TiposAportes TipoAporte);
        Task<ServiceResponse<TiposAportes>> Modificar(TiposAportes tipoAporte);
        Task<ServiceResponse<TiposAportes>> Eliminar(TiposAportes TipoAporte);
    }
}
