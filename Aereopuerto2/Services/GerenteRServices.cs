using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Services
{
    public class GerenteRServices
    {
        public void UpdateReserva(Cliente request)//recibe todos los datos del cliente
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Cliente update = _context.Cliente.Find(request.PKCliente);
                    update.FKEmpleado = request.FKEmpleado;
                    update.Solicitud = "Listo";
                    update.Estatus = request.Estatus;
                    update.HoraConductor = request.HoraConductor;
                    update.HoraHotel = request.HoraHotel;

                    _context.Cliente.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public void CancelarReserva(Cliente request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Cliente update = _context.Cliente.Find(request.PKCliente);
                    update.FKEmpleado = request.FKEmpleado;
                    update.Estatus = request.Estatus;
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
        public List<Cliente> GetUsuarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Cliente> usuarios = _context.Cliente.Where(x => x.Solicitud != "Listo").ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }
    }
}
