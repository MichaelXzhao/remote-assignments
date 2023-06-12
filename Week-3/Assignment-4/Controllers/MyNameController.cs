using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cookie.Controllers
{
    public class MyNameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string userName = Request.Cookies["UserName"]?? string.Empty;
            if (!string.IsNullOrEmpty(userName))
            {
                ViewBag.UserName = userName;
            }
            return View();
        }
    }

    
}
