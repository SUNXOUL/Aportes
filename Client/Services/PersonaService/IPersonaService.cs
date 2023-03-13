
using Aportes.Shared.Models;

namespace Aportes.Client.Sevices.PersonaService
{
    public interface IPersonaService
    {
        List<Persona> Personas{ get; set; }
        Task GetPersonas();
        Task<ServiceResponse<Persona>> GetPersona(int ID);
        Task<ServiceResponse<Persona>> Eliminar(Persona persona);
        Task<ServiceResponse<Persona>> Guardar(Persona persona);
    }
}
