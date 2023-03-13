using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aportes.Shared.Models
{
    public class AportesDetalle
    {
        [Key]
        public int Id { get; set; }
        public float Valor { get; set; }
        public Persona persona { get; set; }
        public int Tipo { get; set; }

        public AportesDetalle()
        {

        }

        public AportesDetalle(int tipoId, float valor, Persona persona, TiposAportes tipo)
        {
            Id = 0;
            Valor = valor;
            persona = persona;

        }

    }
}
