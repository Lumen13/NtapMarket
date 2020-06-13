using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NtapMarket.Data.IRepository;
using NtapMarket.Data.ObjectModel;
using NtapMarket.Web.Seller.Models;

namespace NtapMarket.Web.Seller.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductModelRepository _productModelRepository;
        private readonly int sellerId = 2;

        public HomeController(ILogger<HomeController> logger, IProductModelRepository productModelRepository)
        {
            _productModelRepository = productModelRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductModel> productModels = _productModelRepository.GetProductModels(sellerId);

            return View(productModels);            
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
