using Aportes.Server.Services.PersonaServices;
using Aportes.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aportes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaServices personaServices;
        public PersonaController(IPersonaServices PersonaService)
        {
            this.personaServices = PersonaService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Persona>>>> GetAllPersons()
        {
            var productos = await personaServices.GetAllPersonasAsync();
            return Ok(productos);
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ServiceResponse<Persona>>> GetPerson(int ID)
        {
            var result = await personaServices.GetPersonaAsync(ID);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Persona>>> Save(Persona persona)
        {
            var result = await personaServices.Guardar(persona);
            return Ok(result); 
        }

        [HttpDelete("{PersonaId}")]
        public async Task<ActionResult<ServiceResponse<Persona>>> Delete(int PersonaId)
        {
            var result = await personaServices.Eliminar(PersonaId);
            return Ok(result);
        }
    }
}
