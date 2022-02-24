using Microsoft.AspNetCore.Mvc;
using ServicesWebMvc.Models;
using ServicesWebMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesWebMvc.Controllers
    {
    public class HomeController : Controller
        {
        public IActionResult Index()
            {
            return View();
            }

        public IActionResult About()
            {
            ViewData["Message"] = "We sell all!";

            return View();
            }

        public IActionResult Contact()
            {
            ViewData["Message"] = "Your contact page.";

            return View();
            }

        public IActionResult Privacy()
            {
            return View();
            }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }
