using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Cliente
    {
        [Key] public int PKCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string INE { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string TipoServicio { get; set; }
        public int Pasajeros { get; set; }
        public string Solicitud { get; set; }
    }
}
