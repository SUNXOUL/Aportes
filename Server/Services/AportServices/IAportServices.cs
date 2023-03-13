using Aportes.Shared.Models;


namespace Aportes.Server.Services.AportServices
{
    public interface IAportServices
    {
        Task<ServiceResponse<Aporte>> GetAporteAsync(int Id);
        Task<ServiceResponse<List<Aporte>>> GetAllAporteAsync();
        Task<ServiceResponse<Aporte>> Guardar(Aporte aporte);
        Task<ServiceResponse<Aporte>> Modificar(Aporte aporte);
        Task<ServiceResponse<Aporte>> Eliminar(Aporte aporte);
    }
}
