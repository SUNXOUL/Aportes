using Aportes.Server.Services.AportServices;
using Aportes.Server.Services.PersonaServices;
using Aportes.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aportes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AporteController : ControllerBase
    {
        private readonly IAportServices AportService;
        public AporteController(IAportServices AportService)
        {
            this.AportService = AportService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Aporte>>>> GetAllAports()
        {
            var productos = await AportService.GetAllAporteAsync();
            return Ok(productos);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ServiceResponse<Aporte>>> GetAport(int ID)
        {
            var result = await AportService.GetAporteAsync(ID);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Aporte>>> Save(Aporte aporte)
        {
            var result = await AportService.Guardar(aporte);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<Aporte>>> Delete(Aporte aporte)
        {
            var result = await AportService.Eliminar(aporte);
            return Ok(result);
        }
    }
}
