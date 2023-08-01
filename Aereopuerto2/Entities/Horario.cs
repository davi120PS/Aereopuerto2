using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Entities
{
    public class Horario
    {
        [Key] public int PKHorario { get; set; }
        [ForeignKey("Conductor")] public int? FKConductor { get; set; }
        public Conductor Conductor { get; set; }
        public string Conductores {get;set;}
        public string Horarios { get;set;}
        public string? Estatus { get;set;}
    }
}
