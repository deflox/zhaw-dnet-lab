using RankingService;

RankingClient client = new RankingClient("http://localhost:5239", new
HttpClient());
ICollection<Competitor> res = await client.GetRankingAsync();
foreach (Competitor c in res)
{
    Console.WriteLine("" + c.Name + " " + c.Time + " F");
}

Console.ReadLine();