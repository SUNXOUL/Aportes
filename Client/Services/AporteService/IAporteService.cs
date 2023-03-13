using Aportes.Shared.Models;

namespace Aportes.Client.Services.AporteService
{
    public interface IAporteService
    {
        List<Aporte> Aportes { get; set; }
        Task GetAportes();
        Task<ServiceResponse<Aporte>> GetAporte(int ID);
        Task<ServiceResponse<Aporte>> Eliminar(Aporte aporte);
        Task<ServiceResponse<Aporte>> Guardar(Aporte aporte);
    }
}
