using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.web.Models;
using Restaurant.web.Services.Interfaces;
using System.Diagnostics;

namespace Restaurant.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;

        public HomeController(ILogger<HomeController> logger,IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> list = new();
            var response = await _productServices.GetAllProductAsync<ResponseDto>();
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> Details(int productId)
        {
            ProductDto singleProduct = new();
            var response = await _productServices.GetSingleProductAsync<ResponseDto>(productId);
            if (response != null && response.IsSuccess)
            {
                singleProduct = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }
            return View(singleProduct);
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

        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies","oidc");
        }
    }
}