using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Sistema
    {
        [Key] public int PKSistemas { get; set; }
        public string Detalles { get; set; }
        [ForeignKey("Empleados")] public int? FKEmpleado { get; set; }
        public Empleado Empleados { get; set; }
    }
}
