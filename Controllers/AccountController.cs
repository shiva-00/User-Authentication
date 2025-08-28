using Microsoft.AspNetCore.Mvc;
using MyApp.Model;
using MyApp.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MyApp.controller
{
    public class AccountController : Controller
    {
        private readonly MyDatabase Data;
        private readonly PasswordHasher<User> Encrypt;

        public AccountController(MyDatabase data)
        {
            Data = data;
            Encrypt = new PasswordHasher<User>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            var Existinguser = Data.Users.FirstOrDefault(E => E.Email == user.Email);
            if (Existinguser != null)
            {
                ModelState.AddModelError("Email", "Email Already Exists. Please TryAgain");
                return View(user);
            }
            if (ModelState.IsValid && user.Password == user.C_Password)
            {
                var newuser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = Encrypt.HashPassword(user, user.Password)
                };

                Data.Users.Add(newuser);
                Data.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else if (user.Password != user.C_Password)
                ModelState.AddModelError("C_Password", "Passwords do not match. Please Try Again");
            return View(user);

        }
        [HttpGet]
        public IActionResult WebPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User loginuser)
        {
            var user = Data.Users.FirstOrDefault(E => E.Email == loginuser.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "User Doesnot Exist. Please Enter Valid Credentials. ");
                return View(loginuser);
            }
            var result = Encrypt.VerifyHashedPassword(user, user.Password, loginuser.Password);

            if (result == PasswordVerificationResult.Success)
                return View("WebPage", user);

            ModelState.AddModelError("Password", "Password Incorrect. Please Enter again. ");
            return View(loginuser);

        }

        [HttpGet]
        public IActionResult Forgot_Password()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Forgot_Password(UserOtp userotp)
        {
            if (ModelState.IsValid)
            {
                var otp = new Random().Next(100000, 999999);
                var record = new UserOtp
                {
                    Email = userotp.Email,
                    Otp = otp,
                    Expire = DateTime.Now.AddMinutes(5)

                };
                Data.userotp.Add(record);
                Data.SaveChanges();
                return RedirectToAction("Verify_Otp", new { email = userotp.Email });
            }
            return View(userotp);

        }

        [HttpGet]
        public IActionResult Verify_Otp(string email)
        {
            var model = new UserOtp { Email = email };
            return View(model);
        }
        [HttpPost]
        public IActionResult Verify_Otp(UserOtp userOtp)
        {
            var otp = Data.userotp.FirstOrDefault(E => E.Email == userOtp.Email);
            if (otp != null && otp.Otp == userOtp.Otp && otp.Expire > DateTime.Now)
            {
                Data.userotp.Remove(otp);
                return RedirectToAction("Password_Reset", new { email = userOtp.Email });                    
            }
            ModelState.AddModelError("Otp", "InValid or Expired Otp. Please try Again.");
            
            return View(userOtp);
        }
        
    }
}