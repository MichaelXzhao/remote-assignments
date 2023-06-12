using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData(string? number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return Ok("Lack of Parameter");
            }
            else if (!long.TryParse(number, out long n))
            {
                return Ok("Wrong Parameter");
            }
            else 
            {
                long sum = n*(n+1)/2;
                

                return Ok(sum);
            }

            
        }
    }
}
