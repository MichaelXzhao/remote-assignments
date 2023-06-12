using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cookie.Controllers
{
    public class TrackNameController : Controller
    {
        [HttpPost]
        public IActionResult Index(string name)
        {
            Response.Cookies.Append("UserName", name);
            return RedirectToAction("Index", "MyName");
        }
    }
}
