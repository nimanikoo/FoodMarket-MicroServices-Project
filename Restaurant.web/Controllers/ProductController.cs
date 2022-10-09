using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.web.Models;
using Restaurant.web.Services.Interfaces;

namespace Restaurant.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productsService;
        public ProductController(IProductServices productsService)
        {
            _productsService = productsService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> productList = new();
            var response = await _productsService.GetAllProductAsync<ResponseDto>();
            if (productList != null && response.IsSuccess)
            {
                productList = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(productList);
        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _productsService.CreatePoductAsync<ResponseDto>(productDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDto);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var response = await _productsService.GetSingleProductAsync<ResponseDto>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto singleProduct = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(singleProduct);
            }
            return NotFound("Oops Not Found any product...");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _productsService.UpdatePoductAsync<ResponseDto>(productDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDto);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await _productsService.GetSingleProductAsync<ResponseDto>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto singleProduct = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(singleProduct);
            }
            return NotFound("Oops Not Found any product...");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _productsService.DeletePoductAsync<ResponseDto>(productDto.ProductId);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDto);
        }


    }
}
