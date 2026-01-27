using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace MVC_Assignment.Controllers {

    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public string ProductDetails { get; set; }
    }

    public class ProductController: Controller
    {
    

    List<Product> products = new List<Product>()
        {
            new Product(){ ProductId=1, ProductName="Laptop", ProductPrice = 100, ProductDetails = "High performance laptop"},
            new Product(){ ProductId=2, ProductName="Smartphone", ProductPrice = 200, ProductDetails = "Latest model smartphone"},
            new Product(){ ProductId=3, ProductName="Tablet", ProductPrice = 300, ProductDetails = "Lightweight tablet"}
        };


        [HttpGet]
        public IActionResult Index() {
            return View(model: products);
        }


        [HttpGet("{id}")]
        [OutputCache]
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
