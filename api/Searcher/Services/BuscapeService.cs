using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace Searcher.Services
{
    public class BuscapeService : IBuscapeService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public BuscapeService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
        }

        public Dictionary<string, string> SearchProducts(string category, int page)
        {
            var dict = new Dictionary<string, string>();
            var url = $"https://www.buscape.com.br/search?q={category}&page={page}";

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            var html = _httpClient.GetStringAsync(url).Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var products = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("data-testid", "product-card")
                .Equals("product-card")).ToList();

            foreach (var product in products)
            {
                var name = product.Descendants("h2")
                    .FirstOrDefault()?.InnerText.Trim();

                var price = product.Descendants("p")
                    .FirstOrDefault(node => node.GetAttributeValue("data-testid", "product-card::price")
                    .Contains("product-card::price"))?.InnerText.Trim();

                if (name != null && price != null && !dict.ContainsKey(name) && price != "TV" && !price.Contains("resultados"))
                    dict.Add(name, price);
            }

            return dict;
        }

    }
}

