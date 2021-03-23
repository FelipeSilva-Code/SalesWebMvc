using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Models;
using System.Diagnostics;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        private readonly DepartmentService _departmentService;

        public ProductsController (ProductService productService, DepartmentService departmentService)
        {
            _productService = productService;
            _departmentService = departmentService;
        }
       
        public async Task<IActionResult> Index()
        {
            var products = await _productService.FindAllAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var productForm = new ProductFormViewModel() { Departments = departments };
            return View(productForm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (Product product)
        {
            if(!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var productForm = new ProductFormViewModel() { Departments = departments };
                return View(productForm);
            }

            try
            {
                await _productService.InsertAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch(EqualException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }


        public IActionResult Error(string message)
        {
            ErrorViewModel viewModel = new ErrorViewModel()
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
