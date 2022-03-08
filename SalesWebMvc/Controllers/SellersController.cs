﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services.Exceptions;
using System.Diagnostics;

namespace SalesWebMvc.Controllers
    {
    public class SellersController : Controller
        {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
            {
            _sellerService = sellerService;
            _departmentService = departmentService;
            }

        public async Task<IActionResult> Index()
            {
            var list = await _sellerService.FindAllAsync();
            return View(list);
            }
        public async Task<IActionResult> Create()
            {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments};
            return View(viewModel);
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
            {
            if (!ModelState.IsValid)
                {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(seller);
                }
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
            }
        public async Task<IActionResult> Delete(int? id)
            {
            if(id == null)
                {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" }) ;
                }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
                {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
                }

            return View(obj);
            }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
            {
            try
                {
                await _sellerService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
                }
            catch (IntegrityException e)
                {
                return RedirectToAction(nameof(Error), new { message = e.Message });
                }
            }
        public async Task<IActionResult> Details(int? id)
            {
            if (id == null)
                {
                return NotFound();
                }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj == null)
                {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
                }

            return View(obj);
            }
        public async Task<IActionResult> Edit(int? id)
            {

            if (id == null)
                {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
                }

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if(obj == null)
                {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found" });
                }
            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
            {
            if (!ModelState.IsValid)
                {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(seller);
                }
            try {
                if (id != seller.Id)
                    {
                    return RedirectToAction(nameof(Error), new { message = "Id Mismatch" });
                    }
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));
                }
            catch(ApplicationException e)
                {
                return RedirectToAction(nameof(Error), new { message = e.Message });
                }
            }
        public IActionResult Error(string message)
            {
            var viewModel = new ErrorViewModel
                {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                };
            return View(viewModel);
            }
        }
    }
