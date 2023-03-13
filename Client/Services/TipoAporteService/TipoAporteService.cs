using Aportes.Client.Pages;
using Aportes.Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Aportes.Client.Services.TiposAporteService
{

    public class TiposAportesService : ITiposAportesService
    {
        private readonly HttpClient _http;

        public TiposAportesService(HttpClient http)
        {
            this._http = http;
        }

        public List<TiposAportes> Tipos { get; set; } = new List<TiposAportes>();

        public async Task GetTiposAportes()
        {
            var resultado = await _http.GetFromJsonAsync<ServiceResponse<List<TiposAportes>>>("api/TiposAportes");
            if (resultado != null && resultado.Data != null)
            {
                Tipos = resultado.Data;
            }
            else
            {
                Console.WriteLine("NoFoundList");
            }
        }

        public async Task<ServiceResponse<TiposAportes>> GetTiposAportes(int ID)
        {
            var resultado = await _http.GetFromJsonAsync<ServiceResponse<TiposAportes>>($"api/TiposAportes/{ID}");
            return resultado;

        }
        public async Task<ServiceResponse<TiposAportes>> Guardar(TiposAportes Tipo)
        {
            var post = await _http.PostAsJsonAsync("api/TipoAporte", Tipo);
            var result = await post.Content.ReadFromJsonAsync<TiposAportes>();
            var response = new ServiceResponse<TiposAportes>();
            response.Data = result;

            return response;
        }
        public async Task<ServiceResponse<TiposAportes>> Eliminar(TiposAportes Tipo)
        {
            var post = await _http.DeleteAsync($"api/TipoAporte{Tipo.TipoAporteId}");
            var result = await post.Content.ReadFromJsonAsync<TiposAportes>();
            var response = new ServiceResponse<TiposAportes>();
            response.Data = result;

            return response;
        }
    }
}
