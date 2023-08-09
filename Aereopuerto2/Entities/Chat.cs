using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Chat
    {
        [Key] public int PKChat { get; set; }
        [ForeignKey("Cliente")] public int? FKCliente { get; set; }
        public Cliente Cliente { get; set; }
        [ForeignKey("Empleado")] public int? FKEmpleado { get; set; }
        public Empleado Empleado { get; set; }
        public string Gerente { get; set; }
        public string Mensaje { get; set; }
    }
}