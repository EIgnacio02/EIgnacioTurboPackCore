using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class TurboApiController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
