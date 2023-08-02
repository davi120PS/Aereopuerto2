using Aereopuerto2.Contex;
using Aereopuerto2.Entities;
using Aereopuerto2.Services;
using MySqlX.XDevAPI.Relational;
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
        public void Update(Empleado request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado update = _context.Empleado.Find(request.PKEmpleado);

                    update.Estatus = request.Estatus;

                    _context.Empleado.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(" Error " + ex.Message);
            }
        }
        public void UpdateMessage(Chat request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Chat update = _context.Chat.Find(request.PKChat);

                    update.Mensaje = request.Mensaje;

                    _context.Chat.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(" Error " + ex.Message);
            }
        }
        public void AddChat(Chat request)
        {
            try
            {
                if (request != null)
                {
                    //Los corchetes son como abrir y cerrar la base de datos
                    using (var _context = new ApplicationDbContext())
                    {
                        Chat res = new Chat();
                        res.Mensaje = request.Mensaje;
                        res.FKCliente = request.FKCliente;
                        res.FKConductor = request.FKConductor;
                        _context.Chat.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }

        }
        public List<Chat> GetChat()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Chat> chat = _context.Chat.ToList();
                    return chat;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error " + ex.Message);
            }
        }
        public void DeleteChat(int chatId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Chat chat = _context.Chat.Find(chatId);
                    if (chat != null)
                    {
                        _context.Remove(chat);
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("No se envio mensaje");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error" + ex.Message);
            }
        }

    }
}
