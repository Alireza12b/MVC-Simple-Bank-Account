using BankAccountManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BankAccountManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _user;

        public HomeController(ILogger<HomeController> logger, IUserRepository user)
        {
            _logger = logger;
            _user = user;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpGet]
        public IActionResult Login(User user)
        {
            var isValidUser = _user.Login(user.NationalId, user.Phone);
            if (isValidUser)
            {
                HttpContext.Session.SetString("NationalId", user.NationalId);
                return RedirectToAction("ShowAccount");
            }
            else
            {
                TempData["LoginFail"] = "Invalid NationalCode or PhoneNumber!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult ShowAccount()
        {
            var nationalId = HttpContext.Session.GetString("NationalId");

            if (string.IsNullOrEmpty(nationalId))
            {
                TempData["LoginFail"] = "Please log in first!";
                return RedirectToAction("Index");
            }

            var showAccount = _user.ShowAccount(nationalId);
            return View(showAccount);
        }

        [HttpPost]
        public IActionResult Withdraw(int amount, string description)
        {
            var nationalId = HttpContext.Session.GetString("NationalId");

            if (string.IsNullOrEmpty(nationalId))
            {
                TempData["LoginFail"] = "Please log in first!";
                return RedirectToAction("Index");
            }

            var isSuccess = _user.Withdraw(nationalId, amount, description);
            if (isSuccess)
            {
                return RedirectToAction("ShowAccount");
            }
            else
            {
                TempData["WithdrawFail"] = "The amount you want to withdraw is more than credit!";
                return RedirectToAction("ShowAccount");
            }
        }

        [HttpPost]
        public IActionResult Deposit(int amount, string description)
        {
            var nationalId = HttpContext.Session.GetString("NationalId");

            if (string.IsNullOrEmpty(nationalId))
            {
                TempData["LoginFail"] = "Please log in first!";
                return RedirectToAction("Index");
            }

            _user.Deposit(nationalId, amount, description);
            return RedirectToAction("ShowAccount");
        }
    }
}