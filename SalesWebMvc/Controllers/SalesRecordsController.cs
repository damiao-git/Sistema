using Microsoft.AspNetCore.Mvc;
using System;
using SalesWebMvc.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
    {
    public class SalesRecordsController : Controller
        {
        private readonly SalesRecordsService _salesRecordService;

        public SalesRecordsController(SalesRecordsService salesRecordService)
            {
            _salesRecordService = salesRecordService;
            }

        public IActionResult Index()
            {
            return View();
            }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
            {
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
            }
        public IActionResult GroupingSearch()
            {
            return View();
            }
        }
    }
