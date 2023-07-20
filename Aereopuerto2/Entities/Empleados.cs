using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Empleados
    {
        [Key] public int PKEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
        public string Matricula { get; set; }
        public string Constraseña { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }
    }
}
