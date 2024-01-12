using Admin.Data;
using Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Admin.Controllers
{
    public class AuthController : Controller
    {
        private readonly AdminContext _context;

        public AuthController(AdminContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["Message"] = "Email dan password harus diisi.";
                return RedirectToAction("Login", "Guests");
            }

            if (email == "admin@gmail.com" && password == "12345")
            {
                // Admin login
                SetRoleCookie("Admin");
                return RedirectToAction("Index", "Dashboard");
            }
            else if (email == "customer@gmail.com" && password == "12345")
            {
                // Customer login
                SetRoleCookie("Customer");
                var combinedModel = new Admin.Models.CombinedModel(); // Buat objek CombinedModel sesuai kebutuhan
               return RedirectToAction("Index", "Customer"); // URL lengkap ke halaman Guests/Index
            }


            else
            {
                TempData["Message"] = "Email atau password salah.";
                return RedirectToAction("Login", "Guests");
            }
        }

        private void SetRoleCookie(string role)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Append("hak_akses", role, options);
        }
    }
}
