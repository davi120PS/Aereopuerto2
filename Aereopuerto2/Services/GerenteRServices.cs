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
    }
}
