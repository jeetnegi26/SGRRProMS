using Account;
using DataModels;
using sgrrpms.web.App_Start;
using System.Web.Mvc;
using Unity;
using UserRepositoryData;

namespace sgrrpms.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDataModel user)
        {
            if (ModelState.IsValid)
            {
                var accountService = UnityConfig.Container.Resolve<IAccountService>();
                var loginSuccess = accountService.ValidateUser(user.UserName, user.Password);
                if (loginSuccess)
                {
                    // Redirect to home or dashboard
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid login attempt.";
                }
            }
            return View(user);
        }
    } 
}