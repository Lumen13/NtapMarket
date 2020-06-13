using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NtapMarket.Data.DBModel;
using NtapMarket.Data.IRepository;
using NtapMarket.Data.ObjectModel;
using NtapMarket.Web.Seller.Models;

namespace NtapMarket.Web.Seller.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly int _sellerId = 2;
        private readonly IProductModelRepository _productModelRepository;

        public ProductController(IProductModelRepository productModelRepository)
        {
            _productModelRepository = productModelRepository;
        }

        [HttpGet, Route("{Id:int}")]
        public IActionResult Product(int id)
        {
            ProductModel productModel = _productModelRepository.GetProductModel(id);

            if (productModel == null)
            {
                return NotFound();                                                  // null-page check
            }

            return View(productModel);
        }

        [HttpGet, Route("Create")]
        public IActionResult AddProduct()
        {
            return View(new UserProductVM());
        }

        [HttpPost, Route("Create")]
        public IActionResult AddProduct(UserProductVM userProductVM)
        {
            if (ModelState.IsValid == false)
            {
                return View(userProductVM);
            }

            _productModelRepository.PushProductModel(userProductVM, _sellerId);

            return new LocalRedirectResult($"~/Home/Index/");
        }

        [HttpGet, Route("{Id:int}/Edit")]
        public IActionResult EditProduct(int id)
        {
            ProductModel productModel = _productModelRepository.GetProductModel(id);

            return View(productModel);
        }

        [HttpPost, Route("{Id:int}/Edit")]
        public IActionResult EditProduct(ProductModel productModel, ProductImage productImage)
        {            
            _productModelRepository.EditProductModel(productModel, _sellerId);

            return new LocalRedirectResult($"~/Product/{productModel.Id}/");
        }

        [HttpGet, Route("Delete")]
        public IActionResult DeleteProducts()
        {
            _productModelRepository.DeleteProducts(_sellerId);

            return new LocalRedirectResult($"~/");
        }

        [HttpGet, Route("{Id:int}/Delete")]
        public IActionResult DeleteProduct(int id)
        {
            _productModelRepository.DeleteProduct(id);

            return new LocalRedirectResult($"~/");
        }
    }
}