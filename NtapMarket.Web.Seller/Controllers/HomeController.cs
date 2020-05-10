using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Extensions.Logging;
using NtapMarket.Data.DBModel;
using NtapMarket.Data.EF;
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
        private readonly int SellerId = 1;
        IWebHostEnvironment _appEnvironment;                                //      Added

        public string PublicInfo { get; set; }

        public HomeController(ILogger<HomeController> logger
            , IProductModelRepository productModelRepository
            , IWebHostEnvironment appEnvironment)                           //      Received
        {
            _productModelRepository = productModelRepository;
            _logger = logger;
            _appEnvironment = appEnvironment;                               //      Initialized to make work DataContext
        }

        public IActionResult Index()
        {
            List<ProductModel> productModels = _productModelRepository.GetProductModels(SellerId);

            return View(productModels);            
        }

        [Route("Product/{Id}")]
        public IActionResult Product(int id)
        {
            ProductModel productModel = _productModelRepository.GetProductModel(id);

            if (productModel == null)
            {
                return NotFound();                                                  // null-page check
            }
            
            return View(productModel);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct                                // makes method async
            (string name, 
            int count, 
            decimal price, 
            string marketingInfo,
            string CategoryName,
            string CategoryDescription,
            string AttributeModelName,
            string AttributeModelValue,
            string AttributeModelDescription,
            IFormFile uploadedFile)                                                     // added Http.Features Component in the Interface!
        {
            _productModelRepository.SetProductModel
                (name,
                count,
                price, 
                marketingInfo,
                CategoryName,
                CategoryDescription,
                AttributeModelName,
                AttributeModelValue,
                AttributeModelDescription,
                uploadedFile);

            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);                         // async 
                }
            }

            return new LocalRedirectResult($"~/Home/Index/");
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
