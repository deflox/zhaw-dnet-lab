using Microsoft.AspNetCore.Mvc;

namespace RESTService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RankingController : ControllerBase
    {
        private readonly ILogger<RankingController> _logger;

        public RankingController(ILogger<RankingController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRanking")]
        public IEnumerable<Competitor> Get()
        {
            string[] ranks = {"Mueller Stefan,02:31:14","Marti Adrian,2:30:09",
                            "Kiptum Daniel,2:11:31", "Ancay Tarcis,2:20:02",
                            "Kreibuhl Christian,2:21:47", "Ott Michael,2:33:48",
                            "Menzi Christoph,2:27:26", "Oliver Ruben,2:32:12",
                            "Elmer Beat,2:33:53", "Kuehni Martin,2:33:36"};
            List<Competitor> ranklingList = new List<Competitor>();
            foreach (string r in ranks)
            {
                Competitor c = new Competitor()
                {
                    Name = r.Split(',')[0],
                    Time = r.Split(',')[1]
                };
                ranklingList.Add(c);
            };
            return ranklingList;
        }
    }
}