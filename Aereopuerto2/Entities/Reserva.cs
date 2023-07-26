using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Reserva
    {
        [Key] public int PKReservas { get; set; }
        [ForeignKey("Empleados")] public int? FKEmpleado { get; set; }
        public Empleado Empleados { get; set; }
    }
    /*public void add()
    {
        Reservas empleado = new Reservas();
        //empleado.Nombre = 
    }*/
}
