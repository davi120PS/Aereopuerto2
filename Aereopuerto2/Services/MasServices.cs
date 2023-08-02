using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Relational;
using System.Windows;

namespace Aereopuerto2.Services
{
    public class MasServices
    {
        public void UpdateHorario(Empleado request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado update = _context.Empleado.Find(request.PKEmpleado);

                    update.Horarios = request.Horarios;
                    //update.Estatus = request.Estatus;

                    _context.Empleado.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" Error " + ex.Message);
            }
        }
        public List<Conductor> GetConductores()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Conductor> conductor = _context.Conductor.ToList();
                    return conductor;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error " + ex.Message);
            }
        }
    }
}
