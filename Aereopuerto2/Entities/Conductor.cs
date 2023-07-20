using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Conductor : Empleados
    {
        [Key] public int PKConductor { get; set; }
        public int Licencia { get; set; }
        public DateTime FechaContratacion { get; set; }
        public bool Disponibilidad { get; set; }
        public int Calificaciones { get; set; }
        public string? NotasAdicionales { get; set; }
    }
}
