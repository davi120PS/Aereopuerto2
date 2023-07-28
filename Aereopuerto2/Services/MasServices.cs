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
        public void AsignarHorario(Horario request)
        {
            try
            {
                if (request != null)
                {
                    //Los corchetes son como abrir y cerrar la base de datos
                    using (var _context = new ApplicationDbContext())
                    {
                        Horario res = new Horario();
                        res.Conductores = request.Conductores;
                        res.Horarios = request.Horarios;
                        res.Estatus = request.Estatus;
                        res.FKConductor = request.FKConductor;

                        _context.Horarios.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }
        public void Update(Horario request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Horario update = _context.Horarios.Find(request.PKHorario);

                    update.Horarios = request.Horarios;
                    update.Conductores = request.Conductores;
                    update.PKHorario = request.PKHorario;

                    _context.Horarios.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(" Error " + ex.Message);
            }
        }
        public List<Horario> GetHorarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Horario> horarios = _context.Horarios.Include(x => x.Conductor).ToList();
                    return horarios;
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
