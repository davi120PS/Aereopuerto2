using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aereopuerto2.Services
{
    public class EmpleadoServices
    {
        public Empleado Login(string UserName, string Password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var usuario = _context.Empleado.FirstOrDefault(x => x.Matricula == UserName && x.Contraseña == Password);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }
        public void Add(Empleado request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Empleado res = new Empleado();
                        res.Nombre = request.Nombre;
                        res.Puesto = request.Puesto;
                        res.Matricula = request.Matricula;
                        res.Contraseña = request.Contraseña;
                        res.Correo = request.Correo;
                        res.Sexo = request.Sexo;
                        _context.Empleado.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public void Update(Empleado request)//recibe todos los datos del empleado
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado update = _context.Empleado.Find(request.PKEmpleado);
                    update.Nombre = request.Nombre;
                    update.Puesto = request.Puesto;
                    update.Matricula = request.Matricula;
                    update.Contraseña = request.Contraseña;
                    update.Sexo = request.Sexo;
                    update.Correo = request.Correo;
                    _context.Empleado.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error" + ex.Message);
            }
        }
        public List<Empleado> GetEmpleados()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Empleado> empleados = _context.Empleado.ToList();
                    return empleados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
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
        public List<Cliente> GetClientes()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Cliente> client = _context.Cliente.ToList();
                    return client;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error " + ex.Message);
            }
        }
    }
}
