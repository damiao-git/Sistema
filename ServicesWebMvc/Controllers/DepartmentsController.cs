using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicesWebMvc.Models;

namespace ServicesWebMvc.Controllers
    {
    public class DepartmentsController : Controller
        {
        public IActionResult Index()
            {
            List<Department> listDep = new List<Department>();
            listDep.Add(new Department(1, "Cars"));
            listDep.Add(new Department(2, "Motorcycles"));

            return View(listDep);
            }
        }
    }
