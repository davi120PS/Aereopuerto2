using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using Aereopuerto2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aereopuerto2.Services
{
    public class ConductorSevices
    {
        public void Update(Horario request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Horario update = _context.Horarios.Find(request.PKHorario);

                    update.Estatus = request.Estatus;

                    _context.Horarios.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(" Error " + ex.Message);
            }
        }
    }
}
