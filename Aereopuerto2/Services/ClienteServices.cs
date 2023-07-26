using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace Aereopuerto2.Services
{
    public class ClienteServices
    {
        public void Add(Cliente request)
        {
            try
            {   //Habre la cadena de conexion y todo lo que se encuentre en using entrará a la DB
                using (var _context = new ApplicationDbContext())
                {
                    Cliente empleado = new Cliente()
                    {
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                        Edad = request.Edad,
                        INE = request.INE,
                        Telefono = request.Telefono,
                        Correo = request.Correo,
                        TipoServicio = request.TipoServicio,
                        Pasajeros = request.Pasajeros,
                        Solicitud = "Aceptable"
                    };
                    _context.Cliente.Add(empleado);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public Cliente Read(int Id)
        {
            try
            {
                Cliente empleado = new Cliente();
                using (var _context = new ApplicationDbContext())
                {   // Buscar el empleado por su Id
                    empleado = _context.Cliente.Find(Id);
                    return empleado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public void Update(Cliente request)//recibe todos los datos del empleado
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Cliente update = _context.Cliente.Find(request.PKCliente);
                    update.Nombre = request.Nombre;
                    update.Apellido = request.Apellido;
                    update.Edad = request.Edad;
                    update.INE = request.INE;
                    update.Telefono = request.Telefono;
                    update.Correo = request.Correo;
                    update.TipoServicio = request.TipoServicio;
                    update.Pasajeros = request.Pasajeros;
                    update.Solicitud = request.Solicitud;

                    _context.Cliente.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }

    }
}
