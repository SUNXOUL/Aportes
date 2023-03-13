using System.ComponentModel.DataAnnotations;
namespace Aportes.Shared.Models
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }

        public String? Nombre { get; set; }
        public String? Telefono { get; set; }
        public String? Celular { get; set; }
        public String? Email { get; set; }
        public String? Direccion { get; set; }
        public double? Aporte { get; set; }

        public DateTime? F_Nacimiento { get; set; }
    }

}