using Aportes.Shared.Models;
using Aportes.Server.DAL;
using Microsoft.EntityFrameworkCore;
using Aportes.Server.Services.AportTypeServices;

namespace Aportes.Server.Services.AportServices
{
    public class AportTypeServices : IAportTypeServices
    {
        private Contexto _contexto { get; set; }

        public AportTypeServices(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<ServiceResponse<TiposAportes>> GetTipoAporteAsync(int Id)
        {
            var response = new ServiceResponse<TiposAportes>();
            var aporte = await _contexto.TiposAportes.FindAsync(Id);
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
        public async Task<ServiceResponse<List<TiposAportes>>> GetAllTipoAporteAsync()
        {
            var response = new ServiceResponse<List<TiposAportes>>();
            response.Data = await _contexto.TiposAportes.ToListAsync();
            return response;

        }


        public async Task<ServiceResponse<TiposAportes>> Guardar(TiposAportes TipoAporte)
        {
            if (await Existe(TipoAporte.TipoAporteId))
                return await Modificar(TipoAporte);
            else
                return await Insertar(TipoAporte);
        }

        public Task<bool> Existe(int TipoAporteId)
        {
            return _contexto.TiposAportes.AnyAsync(o => o.TipoAporteId == TipoAporteId);
        }

        private async Task<ServiceResponse<TiposAportes>> Insertar(TiposAportes TipoAporte)
        {
            var response = new ServiceResponse<TiposAportes>();

            try
            {
                _contexto.TiposAportes.Add(TipoAporte);
                bool guardado = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(TipoAporte).State = EntityState.Detached;

                response.Data = TipoAporte;
                response.Success = guardado;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Messagge = ex.Message;
                response.Data = TipoAporte;
            }

            return response;
        }

        public async Task<ServiceResponse<TiposAportes>> Modificar(TiposAportes TipoAporte)
        {
            var response = new ServiceResponse<TiposAportes>();

            try
            {
                _contexto.Entry(TipoAporte).State = EntityState.Modified;
                var guardo = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(TipoAporte).State = EntityState.Detached;


                response.Data = TipoAporte;
                response.Success = guardo;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Messagge = ex.Message;
                response.Data = TipoAporte;
            }

            return response;

        }
        public async Task<ServiceResponse<TiposAportes>> Eliminar(TiposAportes TipoAporte)
        {
            var response = new ServiceResponse<TiposAportes>();

            try
            {
                _contexto.Remove(TipoAporte);
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM AportesDetalle WHERE Tipo={TipoAporte.TipoAporteId};");
                bool guardardo = await _contexto.SaveChangesAsync() > 0;

                response.Success = false;
                response.Data = TipoAporte;

            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Messagge = ex.Message;
                response.Data = TipoAporte;
            }

            return response;


        }
    }
}
