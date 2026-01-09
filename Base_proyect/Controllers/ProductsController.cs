using Microsoft.AspNetCore.Mvc;
using Base_proyect.Models;
using Base_proyect.Services.Interfaces;

namespace Base_proyect.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _Service;


        public ProductsController(IProductService Service)
        {
            _Service = Service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_Service.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_Service.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(Product product) {
            var created = _Service.Create(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpPut]
        public IActionResult Update(int id, Product product) { 
            var update= _Service.Update(id, product);
            if (update == null)
                return NotFound();
            return Ok(update);
        
        
        }
        [HttpDelete]
        public IActionResult Delete(int id) {
            _Service.Delete(id);
            return NoContent();     
        }

    }
}
