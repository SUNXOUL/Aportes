using Aportes.Shared.Models;
using Aportes.Server.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aportes.Server.Services.AportServices
{
    public class AportServices : IAportServices
    { 
        private Contexto _contexto {get;set;}

        public AportServices( Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ServiceResponse<Aporte>> GetAporteAsync(int Id)
        {
            var response = new ServiceResponse<Aporte>();
            var aporte = await _contexto.Aportes.FindAsync(Id);
            if (aporte == null)
            {
                response.Success = false;
                response.Messagge = "este aporte no existe";
            }
            else
            {
                response.Data = aporte;
            }

            return response;

        }
        public async Task<ServiceResponse<List<Aporte>>> GetAllAporteAsync()
        {
            var response = new ServiceResponse<List<Aporte>>();
            response.Data = await _contexto.Aportes.Include(a => a.DetalleAporte).ToListAsync();
            return response;
        }



        public async Task<ServiceResponse<Aporte>> Guardar(Aporte aporte)
        {
            if (await Existe(aporte.AporteId))
                return await Modificar(aporte);
            else
                return await Insertar(aporte);
        }

        public Task<bool> Existe(int aporteId)
        {
            return _contexto.Aportes.AnyAsync(o => o.AporteId == aporteId);
        }

        private async Task<ServiceResponse<Aporte>> Insertar(Aporte Aporte)
        {
            var response = new ServiceResponse<Aporte>();

            try
            {
                _contexto.Aportes.Add(Aporte);

                foreach (var detalle in Aporte.DetalleAporte)
                {
                    Aporte.Monto += detalle.Valor;
                }

                //Agregamos el monto del balance de la persona
                var persona = _contexto.Personas.Find(Aporte.PersonaId);
                persona.Aporte -= Aporte.Monto;
                _contexto.Entry(persona).State = EntityState.Modified;
                bool guardado = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(persona).State = EntityState.Detached;

                response.Data = Aporte;
                response.Success = guardado;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Messagge = ex.Message;
                response.Data = Aporte;
            }

            return response;
        }

        public async Task<ServiceResponse<Aporte>> Modificar(Aporte aporte)
        {
            var response = new ServiceResponse<Aporte>();

            try
            {
                var anterior = _contexto.Aportes
                .Where(c => c.AporteId == aporte.AporteId)
                .Include(c => c.DetalleAporte)
                .AsNoTracking()
                .SingleOrDefault();

                //eliminamos los antiguos montos detalles del pago
                foreach (var item in anterior.DetalleAporte)
                {
                    aporte.Monto -= item.Valor;
                }


                //Modificamos el monto del balance de la persona
                if (anterior.Monto != aporte.Monto)
                {
                    var persona = _contexto.Personas.Find(aporte.PersonaId);
                    persona.Aporte -= anterior.Monto;
                    persona.Aporte += aporte.Monto;
                    _contexto.Entry(persona).State = EntityState.Modified;
                    await _contexto.SaveChangesAsync() ;
                    _contexto.Entry(persona).State = EntityState.Detached;
                }

                //agregamos los nuevos montos al pago
                foreach (var item in aporte.DetalleAporte)
                {
                    aporte.Monto += item.Valor;

                    _contexto.Entry(item).State = EntityState.Added;
                }

                //actualizamos el pago
                _contexto.Entry(aporte).State = EntityState.Modified;
                bool guardo = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(aporte).State = EntityState.Detached;



                response.Data = aporte;
                response.Success = guardo;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Messagge = ex.Message;
                response.Data = aporte;
            }

            return response;
            
        }
        public  async Task<ServiceResponse<Aporte>> Eliminar(Aporte aporte)
        {
            var response = new ServiceResponse<Aporte>();

            try
            {

                //eliminamos el monto del balance de la persona
                var persona = _contexto.Personas.Find(aporte.PersonaId);
                persona.Aporte += aporte.Monto;
                _contexto.Entry(persona).State = EntityState.Modified;
                bool guardardo = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(persona).State = EntityState.Detached;

                _contexto.Remove(persona);

                response.Data = aporte;
                response.Success = guardardo;  
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Messagge = ex.Message;
                response.Data = aporte;
            }

            return response;


        }

    }
}
