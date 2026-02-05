using Microsoft.AspNetCore.Mvc;
using MVC_Assignment.Models;

namespace MVC_Assignment.Controllers {
    public class ProductController: Controller
    {
        // Should be static to maintain data across requests
        private static readonly List<ProductViewModel> products = new()
        {
            new ProductViewModel(){ ProductId=1, ProductName="Laptop", ProductPrice = 100, ProductDetails = "High performance laptop"},
            new ProductViewModel(){ ProductId=2, ProductName="Smartphone", ProductPrice = 200, ProductDetails = "Latest model smartphone"},
            new ProductViewModel(){ ProductId=3, ProductName="Tablet", ProductPrice = 300, ProductDetails = "Lightweight tablet"}
        };

        [HttpGet]
        public IActionResult Index() {
            return View(model: products);
        }

        [HttpGet] // Fixed: removed incorrect "{id}" template
        public IActionResult Details(int id)
        {

            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                return View(model: product);
            }
            return NotFound();
        }
    }
}
