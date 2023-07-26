using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Reserva : Empleado
    {
        [Key] public int PKReservas { get; set; }
    }
    /*public void add()
    {
        Reservas empleado = new Reservas();
        //empleado.Nombre = 
    }*/
}
