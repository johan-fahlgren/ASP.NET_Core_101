using Microsoft.AspNetCore.Mvc;
using MyCrafts.WebSite.Models;
using MyCrafts.WebSite.Services;

namespace MyCrafts.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public JsonFileProductService ProductService { get; }

        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Product>? Get()
        {
            return ProductService.GetProducts();
        }

        //[HttpPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string ProductId, [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}
