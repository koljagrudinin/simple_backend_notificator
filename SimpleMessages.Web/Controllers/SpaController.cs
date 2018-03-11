using Microsoft.AspNetCore.Mvc;

namespace SimpleMessages.Web.Controllers
{
    public class SpaController: Controller
    {
        public IActionResult Spa()
        {
            return File("~/index.html", "text/html");
        }
    }
}