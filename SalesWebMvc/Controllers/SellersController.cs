using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        
        private readonly SellerService _sellerService;
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        

        /*private readonly SalesWebMvcContext _context;
        public SellersController(SalesWebMvcContext context)
        {
            _context = context;
        }
        */
        

        public IActionResult Index()
        {
            return View( _sellerService.FindAll());
        }
    }
}
