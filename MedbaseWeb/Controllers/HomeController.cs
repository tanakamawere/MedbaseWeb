using MedbaseWeb.Utils;
using System.Diagnostics;

namespace MedbaseWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApiService apiService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            apiService = new ApiService();
        }

        public IActionResult Index()
        {
            return View(apiService.GetHomeArticles());
        }
        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("article")]
        public IActionResult ArticleView(int id)
        {
            return View(apiService.GetArticle(id));
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
        [Route("downloads")]
        public IActionResult Downloads()
        {
            return View();
        }

        [Route("articles")]
        public IActionResult Articles()
        {
            return View(apiService.GetArticles());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}