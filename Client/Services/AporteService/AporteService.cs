using Aportes.Client.Pages;
using Aportes.Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Aportes.Client.Services.AporteService
{

    public class AporteService : IAporteService
    {
        private readonly HttpClient _http;

        public AporteService(HttpClient http)
        {
            this._http = http;
        }

        public List<Aporte> Aportes { get; set; } = new List<Aporte>();

        public async Task GetAportes()
        {
            var resultado = await _http.GetFromJsonAsync<ServiceResponse<List<Aporte>>>("api/Aporte");
            if (resultado != null && resultado.Data != null)
            {
                Aportes = resultado.Data;
            }
            else
            {
                Console.WriteLine("NoFoundList");
            }
        }

        public async Task<ServiceResponse<Aporte>> GetAporte(int ID)
        {
            var resultado = await _http.GetFromJsonAsync<ServiceResponse<Aporte>>($"api/Aporte/{ID}");
            return resultado;

        }
        public async Task<ServiceResponse<Aporte>> Guardar(Aporte aporte)
        {
            var post = await _http.PostAsJsonAsync("api/Aportes", aporte);
            var result = await post.Content.ReadFromJsonAsync<Aporte>();
            var response =  new ServiceResponse<Aporte>();
            response.Data = result;
            
            return response;
        }
        public async Task<ServiceResponse<Aporte>> Eliminar(Aporte aporte)
        {
            var post = await _http.DeleteAsync($"api/Aportes{aporte.AporteId}");
            var result = await post.Content.ReadFromJsonAsync<Aporte>();
            var response = new ServiceResponse<Aporte>();
            response.Data = result;

            return response;
        }

    }
}
