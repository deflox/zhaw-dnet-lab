using ASPWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RankingService;

namespace ASPWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            RankingClient client = new RankingClient("http://localhost:5239", new
            HttpClient());

            Task<ICollection<Competitor>> task = client.GetRankingAsync();
            while (!task.IsCompleted) { }

            ICollection<Competitor> res = task.Result;
            return View(res);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}