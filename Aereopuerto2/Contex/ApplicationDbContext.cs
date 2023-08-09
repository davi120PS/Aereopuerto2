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
        public DbSet<Sistema> Sistema { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    PKEmpleado = 1,
                    Nombre = "David",
                    Puesto = "Sistema",
                    Matricula = "davi",
                    Contraseña = "123",
                    Correo = "davi@",
                    Sexo = "Hombre",
                    Horarios = "",
                    Estatus = "",
                    Conexion = 0
                },
                new Empleado
                {
                    PKEmpleado = 2,
                    Nombre = "Diego",
                    Puesto = "Reservas",
                    Matricula = "dieg",
                    Contraseña = "123",
                    Correo = "dieg@",
                    Sexo = "Hombre",
                    Horarios = "",
                    Estatus = "",
                    Conexion = 0
                },
                new Empleado
                {
                    PKEmpleado = 3,
                    Nombre = "Jorge",
                    Puesto = "Conductor",
                    Matricula = "joge",
                    Contraseña = "123",
                    Correo = "joge@",
                    Sexo = "Hombre",
                    Horarios = "2PM-10PM",
                    Estatus = "Disponible",
                    Conexion = 0
                },
                new Empleado
                {
                    PKEmpleado = 4,
                    Nombre = "Jonathan",
                    Puesto = "Conductor",
                    Matricula = "jony",
                    Contraseña = "123",
                    Correo = "joge@",
                    Sexo = "Hombre",
                    Horarios = "10PM-6AM",
                    Estatus = "Disponible",
                    Conexion = 0
                }
            );
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    PKCliente = 1,
                    Nombre = "Paco",
                    Apellido = "Rabanne",
                    Edad = 36,
                    INE = "PACCB24",
                    Telefono = 23412,
                    Correo = "paco@",
                    TipoServicio = "VIP",
                    Pasajeros = 1,
                    Solicitud = "Aceptable",
                    Estatus = "Por confirmar",
                    NombreConductor = "",
                    HoraConductor = "POR ASIGNAR",
                    HoraHotel = "POR ASIGNAR"
                },
                new Cliente
                {
                    PKCliente = 2,
                    Nombre = "Carolina",
                    Apellido = "Herrera",
                    Edad = 23,
                    INE = "CAHR3G",
                    Telefono = 87868,
                    Correo = "caro@",
                    TipoServicio = "Premium",
                    Pasajeros = 2,
                    Solicitud = "Aceptable",
                    Estatus = "Por confirmar",
                    NombreConductor = "",
                    HoraConductor = "POR ASIGNAR",
                    HoraHotel = "POR ASIGNAR"
                }
            );
        }
    }
}