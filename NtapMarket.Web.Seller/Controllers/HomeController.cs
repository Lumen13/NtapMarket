using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NtapMarket.Data.DBModel;
using NtapMarket.Data.IRepository;
using NtapMarket.Data.Mock.Repository;
using NtapMarket.Data.ObjectModel;
using NtapMarket.Web.Seller.Models;

namespace NtapMarket.Web.Seller.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductModelRepository _productModelRepository;
        Product product = new Product();

        public HomeController(ILogger<HomeController> logger
            , IProductModelRepository productModelRepository)
        {
            _productModelRepository = productModelRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductModel> productModels = _productModelRepository.GetProductModel(product.SellerId, product.Id);

            for (int i = productModels.Count - 1; i >= 0; i--)
            {
                if (productModels[i].SellerId != 1)
                {
                    productModels.RemoveAt(i);
                }
            }
            return View(productModels);            
        }

        [Route("Product/{Id:int}")]
        public IActionResult Id()
        {
            List<ProductModel> productModels = _productModelRepository.GetProductModel(product.SellerId, product.Id);
            for (int i = productModels.Count - 1; i >= 0; i--)
            {
                if (productModels[i].Id != product.Id)
                {
                    productModels.RemoveAt(i);
                }
            }
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
