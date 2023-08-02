using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aereopuerto2.Entities;

namespace Aereopuerto2.Contex
{
    public class ApplicationDbContext : DbContext //Hereda una libreria de EntityFramework  
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Cadena de conexion - Ocupas instalar PaqueteNuGet MySQL.MicrosoftEntities...
            optionsBuilder.UseMySQL("server=localhost; database=Aereopuerto23AM; user=root; password=");
        }
        //Mapeo de la BD
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Conductor> Conductor { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Sistema> Sistema { get; set; }
    }
}
