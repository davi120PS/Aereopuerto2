﻿using Aereopuerto2.Contex;
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
        public List<Cliente> GetUsuarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Cliente> usuarios = _context.Cliente.ToList();
                    //List<Usuario> usuarios = new List<Usuario>();
                    //usuarios = _context.Usuarios.ToList();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
        public void UpdateReserva(Cliente request)//recibe todos los datos del cliente
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Cliente update = _context.Cliente.Find(request.PKCliente);
                    update.FKConductor = request.FKConductor;
                    update.Solicitud = "Listo";
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
    }
}
