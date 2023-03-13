using Aportes.Server.Services.AportTypeServices;
using Aportes.Server.Services.PersonaServices;
using Aportes.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aportes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAporteController : ControllerBase
    {
        private readonly IAportTypeServices AportTypeService;
        public TipoAporteController(IAportTypeServices aportTypeService)
        {
            this.AportTypeService = aportTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TiposAportes>>>> GetProduct()
        {
            var productos = await AportTypeService.GetAllTipoAporteAsync();
            return Ok(productos);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ServiceResponse<TiposAportes>>> GetProduct(int ID)
        {
            var result = await AportTypeService.GetTipoAporteAsync(ID);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<TiposAportes>>> Save(TiposAportes Tipo)
        {
            var result = await AportTypeService.Guardar(Tipo);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<TiposAportes>>> Delete(TiposAportes Tipo)
        {
            var result = await AportTypeService.Eliminar(Tipo);
            return Ok(result);
        }
    }
}
