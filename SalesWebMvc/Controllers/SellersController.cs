using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;

        public SellersController(SellersService sellerService)
        {
            _sellersService = sellerService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = _sellersService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
