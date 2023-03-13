using Aportes.Shared.Models;
namespace Aportes.Server.Services.PersonaServices
{
    public interface IPersonaServices
    {
        Task<ServiceResponse<Persona>> GetPersonaAsync(int Id);
        Task<ServiceResponse<List<Persona>>> GetAllPersonasAsync();
        Task<ServiceResponse<Persona>> Guardar(Persona persona);
        Task<ServiceResponse<Persona>> Modificar(Persona persona);
        Task<ServiceResponse<Persona>> Eliminar(Persona persona);
    }
}
