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
        [Key] public int PKChat {get; set;}
        [ForeignKey("Cliente")] public int? FKCliente { get; set; }
        public Cliente Cliente { get; set; }
        [ForeignKey("Conductor")] public int? FKConductor { get; set; }
        public Conductor Conductor { get; set; }
        public string Mensaje {get; set;}
    }
}
