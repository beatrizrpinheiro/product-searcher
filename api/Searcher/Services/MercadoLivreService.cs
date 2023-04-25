using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Searcher.Data;
using Searcher.Models;
using System.Globalization;

namespace Searcher.Services
{
    public class MercadoLivreService : IMercadoLivreService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly SearcherContext _context;
        private readonly DbContextOptions<SearcherContext> _dbContextOptions;

        public MercadoLivreService(IConfiguration configuration, DbContextOptions<SearcherContext> dbContextOptions, SearcherContext context)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _dbContextOptions = dbContextOptions;
            _context = context;
        }

        public List<Product> SearchProductsMercadoLivre(string category)
        {
            List<Product> listaProdutos = new List<Product>();
            var url = $"https://lista.mercadolivre.com.br/{category}";

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            var html = _httpClient.GetStringAsync(url).Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var products = htmlDocument.DocumentNode.Descendants("ol")
                .Where(node => node.GetAttributeValue("class", "ui-search-layout ui-search-layout--grid")
                .Equals("ui-search-layout ui-search-layout--grid")).ToList();

            foreach (var product in products)
            {
                var name = product.Descendants("h2")
                    .FirstOrDefault(node => node.GetAttributeValue("class", "ui-search-item__title shops__item-title")
                    .Contains("ui-search-item__title shops__item-title"))?.InnerText.Trim();

                var price = product.Descendants("span")
                    .FirstOrDefault(node => node.GetAttributeValue("class", "price-tag-amount")
                    .Contains("price-tag-amount"))?.InnerText.Trim();

                var imageUrl = product.Descendants("img")
                    .FirstOrDefault(node => node.GetAttributeValue("class", "ui-search-result-image__element shops__image-element")
                    .Contains("ui-search-result-image__element shops__image-element"))?.GetAttributeValue("src", "");

                if (name != null && price != null && !listaProdutos.Any(x => x.Name == name) && price != "TV" && !price.Contains("resultados"))
                {
                    decimal priceResult;
                    string valorSemFormatacao = price.Replace(".", "").Replace(",", ".").Replace("R$", "");
                    decimal.TryParse(valorSemFormatacao, NumberStyles.Currency, CultureInfo.InvariantCulture, out priceResult);

                    listaProdutos.Add(new Product
                    {
                        Name = name,
                        Price = priceResult,
                        ImageUrl = imageUrl,
                        Site = "Mercado Livre"
                    });
                }
            }

            AddSearchResultsAsync(listaProdutos, category);

            return listaProdutos;
        }

        private void AddSearchResultsAsync(List<Product> listaProdutos, string category)
        {
            var products = new List<Product>();

            foreach (var item in listaProdutos)
            {
                products.Add(new Product
                {
                    Name = item.Name,
                    Price = item.Price,
                    Description = item.Description != null ? item.Description : "",
                    Category = category,
                    Site = item.Site,
                    ImageUrl = item.ImageUrl,
                    SearchTerm = category,
                    SearchDate = DateTime.Now
                });
            }

            _context.Product.AddRange(products);
            _context.SaveChanges();

        }
    }
}
