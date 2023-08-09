using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Empleado
    {
        [Key] public int PKEmpleado { get; set; }
        public string Nombre { get; set; }
        public string? Puesto { get; set; }
        public string Matricula { get; set; }
        public string Contraseña { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }
        public string? Horarios { get; set; }
        public string? Estatus { get; set; }
        public int? Conexion { get; set; }
    }
}