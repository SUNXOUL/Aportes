using Aportes.Shared.Models;
using Aportes.Server.DAL;
using Microsoft.EntityFrameworkCore;

namespace Aportes.Server.Services.PersonaServices
{
    public class PersonaServices : IPersonaServices
    { 
        private Contexto _contexto {get;set;}

        public PersonaServices( Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ServiceResponse<Persona>> GetPersonaAsync(int Id)
        {
            var response = new ServiceResponse<Persona>();
            var persona = await _contexto.Personas.FindAsync(Id);
            if (persona == null)
            {
                response.Success = false;
                response.Messagge = "esta persona  no existe";
            }
            else
            {
                response.Data = persona;
            }

            return response;

        }
        public async Task<ServiceResponse<List<Persona>>> GetAllPersonasAsync()
        {
            var response = new ServiceResponse<List<Persona>>();
            response.Data = await _contexto.Personas.ToListAsync();
            return response;

        }


        public async Task<ServiceResponse<Persona>> Guardar(Persona persona)
        {
            if (await Existe(persona.PersonaId))
                return await Modificar(persona);
            else
                return await Insertar(persona);
        }

        public Task<bool> Existe(int PersonaId)
        {
            return _contexto.Personas.AnyAsync(o => o.PersonaId==PersonaId);
        }

        private async Task<ServiceResponse<Persona>> Insertar(Persona persona)
        {
            var response = new ServiceResponse<Persona>();

            try
            {
                _contexto.Personas.Add(persona);
                bool guardado = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(persona).State = EntityState.Detached;

                response.Data = persona;
                response.Success = guardado;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Messagge = ex.Message;
                response.Data = persona;
            }

            return response;
        }

        public async Task<ServiceResponse<Persona>> Modificar(Persona persona)
        { 
            var response = new ServiceResponse<Persona>();

            try
            {
                _contexto.Entry(persona).State = EntityState.Modified;
                var guardo = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(persona).State = EntityState.Detached;



                response.Data = persona;
                response.Success = guardo;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Messagge = ex.Message;
                response.Data = persona;
            }

            return response;

        }
        public async Task<ServiceResponse<Persona>> Eliminar(Persona persona)
        {
            var response = new ServiceResponse<Persona>();

            try
            {
                _contexto.Entry(persona).State = EntityState.Deleted;
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM Personas WHERE PersonaId={persona.PersonaId};");
                _contexto.Entry(persona).State = EntityState.Detached;
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Messagge = ex.Message;
                response.Data = persona;
            }

            return response;


        }
    }
}
