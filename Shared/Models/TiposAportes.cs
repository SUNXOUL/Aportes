﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aportes.Shared.Models
{
    public class TiposAportes
    {
        [Key]
        public int TipoAporteId { get; set; }
        public string Descripcion { get; set; }
        public float Meta { get; set; }
        public float Logrado { get; set; }
    }
}
