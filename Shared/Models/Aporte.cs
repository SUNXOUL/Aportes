using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aportes.Shared.Models
{
    public class Aporte
    {
        [Key]
        //AporteId,Fecha,PersonaId,Concepto, Monto 
        public int AporteId { get; set; }
        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public string? Concepto { get; set; }
        public float Monto { get; set; }

        [ForeignKey("AporteId")]
        public List<AportesDetalle> DetalleAporte { get; set; } = new List<AportesDetalle>();
    }
}
