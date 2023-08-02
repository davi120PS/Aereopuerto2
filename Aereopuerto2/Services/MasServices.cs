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
        public void AsignarHorario(Conductor request)
        {
            try
            {
                if (request != null)
                {
                    //Los corchetes son como abrir y cerrar la base de datos
                    using (var _context = new ApplicationDbContext())
                    {
                        Conductor res = new Conductor();
                        res.Horarios = request.Horarios;
                        res.Estatus = request.Estatus;
                        //res.FKConductor = request.FKConductor;

                        _context.Conductor.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }
        public void Update(Conductor request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Conductor update = _context.Conductor.Find(request.PKConductor);

                    update.Horarios = request.Horarios;
                    update.Estatus = request.Estatus;

                    _context.Conductor.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" Error " + ex.Message);
            }
        }
        public List<Conductor> GetHorarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Conductor> conductores = _context.Conductor
                        .Include(x => x.Empleados)
                        .Include(x => x.Empleados.Nombre)

                        /*.Select (conductor => Empleado
                        {
                            
                        })*/
                        .ToList();
                    return conductores;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
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
        public void DeleteHorario(int HorarioId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Horario horario = _context.Horarios.Find(HorarioId);
                    if (horario != null)
                    {
                        _context.Remove(horario);
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("No hay horario asignado");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
    }
}
