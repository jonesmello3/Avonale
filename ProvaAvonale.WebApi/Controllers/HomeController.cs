using ProvaAvonale.Anticorruption.Services;
using RestEase;
using System.Web.Mvc;

namespace ProvaAvonale.WebApi.Controllers
{
    public class HomeController : Controller
    {
        [Header("User-Agent", "jonesmello3")]
        public ActionResult Index()
        {
            GitHubService gitHubService = new GitHubService();
            var result = gitHubService.ListarRepositoriosPublicos();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}