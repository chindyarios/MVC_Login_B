using MVC_Login_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC_Login_B.Controllers
{
    public class DashboardController : Controller
    {
        ApplicationDbContext Mycontext = new ApplicationDbContext();
        // GET: Dashboard
        public ActionResult Index()
        {
            var Index = Mycontext.Login.ToList();
            return View(Index);
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            var Detail = Mycontext.Login.ToList();
            return View(Detail);
        }
        //Get 
        public ActionResult masuk()
        {

            return View();
        }
        //Get 
        public ActionResult dashboard()
        {

            return View();
        }
        //get 
        public ActionResult forgetpassword()
        {
            var list = Mycontext.Login.ToList();
            return View(list);

        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult masuk(ClassLogin login) // yang ijomuda itu nama class 
        {
            var currentAccount = Mycontext.Login.FirstOrDefault(dta => dta.Email == login.Email);
            if (currentAccount != null)
            {
                var password = BCrypt.Net.BCrypt.Verify(login.Password, currentAccount.Password);
                if (password == true)
                {
                    Session["id"] = login.id;
                    Session.Add("email", login.Email);
                    //retun view ("WELCOME")
                    return RedirectToAction("dashboard", "Login");
                }


            }
            ViewBag.error = "Invalid";
            return View("Index");
        }
        // POST: Register/Create
        [HttpPost]
        public async Task<ActionResult> Create (ClassLogin login)
        {
            login.Password = BCrypt.Net.BCrypt.HashPassword(login.Password);
            Mycontext.Login.Add(login);
            Mycontext.SaveChanges();
            MailMessage sub = new MailMessage("loveablemecin@gmail.com", login.Email);
            sub.Subject = "[Password]" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            sub.Body = "Welcome!" + login.Email + "\nYour New Password: " + login.Password;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("loveablemecin@gmail.com", "bucinnyaJK");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(sub);
            ViewBag.Message = "Password Has Been Sent. Please check your email";
            return RedirectToAction("Index", "login");
        }


        // GET: Login/Create
        public ActionResult Create()
        {

            return View();
        }



        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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