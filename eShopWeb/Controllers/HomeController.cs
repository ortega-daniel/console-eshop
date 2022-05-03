using BusinessLogic.Services.Abstractions;
using eShopWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProviderService _providerService;

        public HomeController(ILogger<HomeController> logger, IProviderService providerService)
        {
            _logger = logger;
            _providerService = providerService;
        }

        public IActionResult Index()
        {
            var data = _providerService.Get();

            return View();
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