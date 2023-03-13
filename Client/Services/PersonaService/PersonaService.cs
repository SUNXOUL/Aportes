using Aportes.Shared.Models;
using System.Net.Http.Json;

namespace Aportes.Client.Sevices.PersonaService
{

    public class PersonaService : IPersonaService
    {
        private readonly HttpClient _http;

        public PersonaService(HttpClient http)
        {
            this._http = http;
        }

        public List<Persona> Personas { get; set; } = new List<Persona>();

        public async Task GetPersonas()
        {
            var resultado = await _http.GetFromJsonAsync<ServiceResponse<List<Persona>>>("api/Persona");
            if (resultado != null && resultado.Data != null)
            {
                Personas = resultado.Data;
            }
            else
            {
                Console.WriteLine("NoFoundList");
            }
        }

        public async Task<ServiceResponse<Persona>> GetPersona(int ID)
        {
            var resultado = await _http.GetFromJsonAsync<ServiceResponse<Persona>>($"api/Persona/{ID}");
            return resultado;

        }

        public async Task<ServiceResponse<Persona>> Guardar(Persona persona)
        {
            var post = await _http.PostAsJsonAsync("api/Persona", persona);
            var result = await post.Content.ReadFromJsonAsync<Persona>();
            var response = new ServiceResponse<Persona>();
            response.Data = result;

            return response;
        }
        public async Task<ServiceResponse<Persona>> Eliminar(Persona persona)
        {
            var post = await _http.DeleteAsync($"api/Persona/{persona.PersonaId}");
            var result = await post.Content.ReadFromJsonAsync<Persona>();
            var response = new ServiceResponse<Persona>();
            response.Data = result;

            return response;
        }
    }
}
