using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;

namespace TP_Chat.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> chats;
        public List<Chat> Chats => chats ?? (chats = Chat.GetMeuteDeChats());

        
        public ActionResult Index()
        {
            return View(Chats);
        }

        public ActionResult Details(int id)
        {
            var chat = Chats.FirstOrDefault(c => c.Id == id);
            if (chat == null)
            {
                return RedirectToAction("Index");
            }

            return View(chat);
        }

        public ActionResult Delete(int id)
        {
            var chat = Chats.FirstOrDefault(c => c.Id == id);
            if (chat == null)
            {
                return RedirectToAction("Index");
            }

            return View(chat);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = Chats.FirstOrDefault(c => c.Id == id);
                if (chat != null)
                {
                    Chats.Remove(chat);
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}