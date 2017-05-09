using System.Web.Mvc;

namespace BookOpinions.Controllers
{
    //[MyAuthorize(Roles = "Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}