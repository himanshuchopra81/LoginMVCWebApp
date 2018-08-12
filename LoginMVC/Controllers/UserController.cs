using LoginMVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login() {
            return View();
        }

        [HttpGet]
        public ActionResult Register(int id=0)
        {
            UserLogin usermodel = new UserLogin();
            return View(usermodel);
        }

        [HttpPost]
        public ActionResult Register(UserLogin userModel)
        {
            using (BoltageEntities dbModel = new BoltageEntities()) {
                if (dbModel.UserLogins.Any(x=>x.Username == userModel.Username)) {
                    ViewBag.DuplicateMessage = "Username Already Exist";
                    return View("Register", userModel);
                }
                userModel.Password = Helper.Hashing.GetHashText(userModel.Password);
                dbModel.UserLogins.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registeration Successful";
            return View("Register", new UserLogin());
        }

        public ActionResult Authorize(UserLogin userLoginModel) {
            using (BoltageUserLoginEntities dbLoginModel = new BoltageUserLoginEntities()) {
                var usercredentials = dbLoginModel.UserLogins.Where(x => x.Username == userLoginModel.Username).FirstOrDefault();
                
                var userData = dbLoginModel.UserLogins.Where(x => x.Username == userLoginModel.Username && x.Password == userLoginModel.Password).FirstOrDefault();
                if (usercredentials.Username == userLoginModel.Username && Helper.Hashing.DecodeText(usercredentials.Password) == userLoginModel.Password) {
                    Session["userID"] = usercredentials.UserID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                  
                    userLoginModel.Password = "Username or Password is incorrect";
                    TempData["msg"] = "<script>alert('Username or Password is incorrect');</script>";
                    ModelState.Clear();
                    return View("Login", userLoginModel);
                }
               
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}