using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using TeloipClient.Models;
using TeloipClient.Repository;

namespace TeloipClient.Controllers
{
    public class HomeController : Controller
    {
        ServiceRepository serviceObj = new ServiceRepository();

        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                string usrpwd = model.Email + ":" + model.Password;
                HttpResponseMessage response = serviceObj.GetResponse("api/Account?userpassword=" + usrpwd);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    Session["User"] = model.Email;
                    Session["Pwd"] = model.Password;

                    return RedirectToAction("UserList", "Home");
                }
                else
                {
                    //ViewBag.Title = "Edit User Data";
                    return View(model);
                }
            }
            catch
            {
                ViewBag.Title = "User Not Found";
                return View();
            }

            
        }

        public ActionResult LogOff()
        {
            Session["User"] = null;
            Session["Pwd"] = null;
            return RedirectToAction("Login", "Home");
        }

        public ActionResult UserList()
        {
            try
            {
                HttpResponseMessage response = serviceObj.GetResponse("api/RestApi");
                response.EnsureSuccessStatusCode();
                List<Models.UserModel> users = response.Content.ReadAsAsync<List<Models.UserModel>>().Result;
                ViewBag.Title = "All Users";
                return View(users);
            }
            catch
            {
                //throw;
                return RedirectToAction("Login");
            }
        }

        public ActionResult UserLog()
        {
            try
            {
                HttpResponseMessage response = serviceObj.GetResponse("api/Auditlogdata");
                response.EnsureSuccessStatusCode();
                List<Models.UserLog> userlog = response.Content.ReadAsAsync<List<Models.UserLog>>().Result;
                ViewBag.Title = "User Log";
                return View(userlog);
            }
            catch
            {
                //throw;
                return RedirectToAction("Login");
            }
        }


        public ActionResult createUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult createUser(UserModel user)
        {
            
            HttpResponseMessage response = serviceObj.PostResponse("api/RestApi/", user);
            if (response.ReasonPhrase == "Found")
            {
                ViewBag.Title = "Duplication Email ID not allowed";
                return View(user);
            }
            else
            {
                if (response.IsSuccessStatusCode == true)
                    return RedirectToAction("UserList"); 
                else
                    return View(user);
            }
        }

        public ActionResult Edit(string id)
        {
            try
            {
                HttpResponseMessage response = serviceObj.GetResponse("api/RestApi/" + id.ToString());
                response.EnsureSuccessStatusCode();
                Models.UserModel users = response.Content.ReadAsAsync<Models.UserModel>().Result;
                ViewBag.Title = "Edit User Data";
                return View(users);
            }
            catch
            {
                ViewBag.Title = "User Not Found";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            HttpResponseMessage response = serviceObj.PutResponse("api/RestApi/", user);
            if (response.ReasonPhrase == "Found")
            {
                ViewBag.Title = "Email ID already registered with other user";
                return View(user);
            }
            else
            {
                if (response.IsSuccessStatusCode == true)
                    return RedirectToAction("UserList", "Home");
                else
                    return View(user);
            }

        }

        public ActionResult Delete(string id)
        {
            HttpResponseMessage response = serviceObj.DeleteResponse("api/RestApi/" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("UserList","Home");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}