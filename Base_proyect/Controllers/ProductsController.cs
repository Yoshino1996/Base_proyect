using Microsoft.AspNetCore.Mvc;
using Base_proyect.Data;
using Base_proyect.Models;

namespace Base_proyect.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var product = _context.Products.ToList();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) 
                return NotFound();

            return Ok(product);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id= product.Id}, product);        
            
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {

            var product = _context.Products.Where(a => a.Id == id).FirstOrDefault();

            if(product ==null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpPut]
        public IActionResult Put([FromBody] Product Update, int id){

            var product = _context.Products.Find(id);

            if(product ==null)
                return NotFound();

            product.Name = Update.Name;
            product.Price = Update.Price;
            product.stock = Update.stock;

            _context.SaveChanges();

            return Ok(product);


        }

    }
}
