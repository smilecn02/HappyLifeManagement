//using System.Net.Mail;
using System.Web.Mvc;
//using Zender.Mail;

namespace HappyLifeManagement.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            //ZenderMessage message = new ZenderMessage("42665282-5bbd-46fd-abea-7b51ef8469cb");
            //MailAddress from = new MailAddress("khactrinhcn02@gmail.com");
            //MailAddress to = new MailAddress("khactrinhcn02@gmail.com");
            //message.From = from;
            //message.To.Add(to);
            //message.Subject = "Welcome!";
            //message.Body = "<p><b>Lorem ipsum</b> dolor sit amet, consectetur adipiscing elit.</p>";
            //message.IsBodyHtml = true;
            //message.SendMailAsync();

            return View();
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
