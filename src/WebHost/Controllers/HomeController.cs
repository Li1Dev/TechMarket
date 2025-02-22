using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechMarket.BLL.DTO;
using TechMarket.BLL.Interfaces;
using TechMarket.Models;

namespace TechMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public HomeController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDTO>? productDTOs = await _productService.GetProducts();
            IEnumerable<ProductViewModel>? products = _mapper.Map<IEnumerable<ProductDTO>?, IEnumerable<ProductViewModel>?>(productDTOs);
            return View(products);
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