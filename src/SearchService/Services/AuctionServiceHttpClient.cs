using System.Net.Http;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService;

public class AuctionServiceHttpClient
{
    private readonly IConfiguration _config;
    private readonly HttpClient _httpClient;

    public AuctionServiceHttpClient(HttpClient httpClient, IConfiguration config)
    {
        _config = config;
        _httpClient = httpClient;
    }

    public async Task<List<Item>> GetItemsForSearchDb()
    {
        var lastUpdated = await DB.Find<Item, string>()
            .Sort(x => x.Descending(x => x.UpdatedAt))
            .Project(x => x.UpdatedAt.ToString())
            .ExecuteFirstAsync();

        return await _httpClient.GetFromJsonAsync<List<Item>>(_config["AuctionServiceUrlCodespace"]+"api/auctions/date="+lastUpdated);
    }
}
