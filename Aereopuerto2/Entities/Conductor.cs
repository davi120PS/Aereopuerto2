using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Conductor
    {
        [Key] public int PKConductor { get; set; }
        [ForeignKey("Empleados")] public int? FKEmpleado { get; set; }
        public Empleado Empleados { get; set; }
        public int Licencia { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int Calificaciones { get; set; }
        public string? NotasAdicionales { get; set; }
    }
}
