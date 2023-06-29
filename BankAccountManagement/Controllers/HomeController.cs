using BankAccountManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BankAccountManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _user;
        public string national;

        public HomeController(ILogger<HomeController> logger , IUserRepository user)
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
            national = user.NationalId;
            var isValidUser = _user.Login(user.NationalId, user.Phone);
            if (isValidUser)
            {
                return RedirectToAction("ShowAccount");
            }
            else
            {
                TempData["LoginFail"] = "Invalid NationalCode or PhoneNumber !";
                return View();
            }
        }

        [HttpGet]
        public IActionResult ShowAccount(string NationalId)
        {
            var showAccount = _user.ShowAccount("10");
            return View(showAccount);
        }

        [HttpPost]
        public IActionResult Withdraw(string NationalId , int amount , string description)
        {
            var isSuccess = _user.Withdraw("10", amount , description);
            if (isSuccess)
            {
                return RedirectToAction("ShowAccount");
            }
            else
            {
                TempData["WithdrawFail"] = "The amount you want to withdraw is more than credit !";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Deposit(string NationalId, int amount, string description)
        {
            _user.Deposit("10", amount, description);
            return RedirectToAction("ShowAccount");
        }

    }
}