using Microsoft.AspNetCore.Mvc;

namespace Base_proyect.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProductsController : Controller
    {

        public static List<int> Numb = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, };


        [HttpGet]
        public IActionResult GetNumb()
        {
            return Ok(Numb);
        }
        [HttpPost]
        public IActionResult PostNumb(int Number)
        {
            Numb.Add(Number);
            return Ok(Numb);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int Number)
        {
            if (Numb.Contains(Number))
                return Ok();
            else
                return NotFound();
        }
    }
}
