using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VerzamelingFinished.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Hard-coded username and password
            string Username = "zuyd";
            string Password = "zuyd";

            // Check if the input matches the hard-coded credentials
            if (username == Username && password == Password)
            {
                // Create a simple session-based authentication token
                HttpContext.Session.SetString("IsAuthenticated", "true");

                // Redirect to Home page after successful login
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If login fails, return an error message
                ViewBag.Error = "Invalid username or password.";
                return View();
            }
        }

        // Logout
        public IActionResult Logout()
        {
            // Clear the authentication session
            HttpContext.Session.Remove("IsAuthenticated");
            return RedirectToAction("Login", "Account");
        }
    }
}

