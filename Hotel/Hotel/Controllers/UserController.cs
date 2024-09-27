

using Microsoft.AspNetCore.Mvc;
using Hotel.Models;
using Hotel.Repository;



namespace Hotel.Controllers
{
    //[Authorize]
    //[Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepo _authService;
        public UserController(IUserRepo authService)
        {
            this._authService = authService;
        }


        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Rooms()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "user";
            var result = await this._authService.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction("SignUp");
        }

        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LogIn(SignInModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var result = await _authService.LoginAsync(model);

            if (result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction("LogIn");
            }
        }

       

        public async Task<IActionResult> RegisterAdmin()
        {
            SignUpModel model = new SignUpModel
            {
                Username = "admin",
                Email = "admin@gmail.com",
                FirstName = "John",
                LastName = "Doe",
                Password = "Admin@12345#"
            };
            if (User.IsInRole("admin"))
            {
                model.Role = "admin";
            }
            else
            {
                model.Role = "user";
            }

            var result = await this._authService.RegisterAsync(model);
            return Ok(result);
        }

        // [Authorize]
        // [Authorize(Roles = "Admin")]


        //public async Task<IActionResult> Adlogin()
        //{
        //    SignUpModel model = new SignUpModel
        //    {

        //        Username = "admin",
        //        Email = "admin@gmail.com",
        //        FirstName = "John",
        //        LastName = "Doe",
        //        Password = "Admin@12345#"
        //    };
        //    if (User.IsInRole("admin"))
        //    {
        //        model.Role = "admin";
        //        return RedirectToAction("Create");
        //    }
        //    else
        //    {
        //        model.Role = "user";
        //    }

        //    var result = await this._authService.RegisterAsync(model);
        //    return Ok(result);
        //}






        //[HttpGet]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> Login(SignInModel model, string returnUrl)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return RedirectToLocal(returnUrl);
        //        case SignInStatus.LockedOut:
        //            return View("Lockout");
        //        case SignInStatus.RequiresVerification:
        //            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        //        case SignInStatus.Failure:
        //        default:
        //            ModelState.AddModelError("", "Invalid login attempt.");
        //            return View(model);
        //    }
        //}

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //   return View("Rooms,Create");
        //}









        ////var result = await this._authService.RegisterAsync(model);
        //[HttpGet]
        //    public IActionResult AdminLogin()
        //    {
        //        return View();
        //    }
        //}
    }
}



