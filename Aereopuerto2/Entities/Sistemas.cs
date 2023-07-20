using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Sistemas : Empleados
    {
        [Key] public int PKSistemas { get; set; }
        public string Detalles { get; set; }
    }
}
