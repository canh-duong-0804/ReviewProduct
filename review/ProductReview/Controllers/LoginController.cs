using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReview.Models;

namespace ProductReview.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(String name, String pass)
        {
            User user=new User();
            using (PRN211Context context = new PRN211Context())
            {

                user = context.Users.FirstOrDefault(p => p.Username == name && p.Password == pass);


                if (user != null)
                {
                    int userid = user.UserId;
                    HttpContext.Session.SetInt32("UserID", userid);
                    HttpContext.Session.SetString("Logout", "Login/LogOut");
                    HttpContext.Session.SetString("messlogout", "logout");
                    HttpContext.Session.SetString("username", "Hello: "+user.Username);
                    if (user.IsAdmin==true)
                    {
                        
                        HttpContext.Session.SetString("Product Menu", "Home/ProductMenu");
                        HttpContext.Session.SetString("manageproduct", "Manage product");
                    }
                
                    return Redirect("~/Home/Index?id=" + user.UserId);
                }
                else
                {
                    Console.WriteLine("dc goi den");
                    HttpContext.Session.SetString("errLogin", "login fail");
                    return Redirect("~/Login/Index");
                }

            }
            
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(String mail,string name, string pass1)
        {
            using(PRN211Context ctx = new PRN211Context())
            {

                User u = new User(name, mail, pass1, DateTime.Now, false);
                ctx.Users.Add(u);
                ctx.SaveChanges();
                //HttpContext.Session.SetString("User", u.Username);
                HttpContext.Session.SetInt32("UserID", u.UserId);
               
                return Redirect("~/Home/Index");
            }

            
            
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
