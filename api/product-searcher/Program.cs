using HtmlAgilityPack;

string categoria = "Geladeira";
int page = 1;

Dictionary<string, string> _dict = new Dictionary<string, string>();

var url = $"https://www.buscape.com.br/search?q={categoria}&page={page}";

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

var html = await httpClient.GetStringAsync(url);

var htmlDocument = new HtmlDocument();
htmlDocument.LoadHtml(html);

var produtos = htmlDocument.DocumentNode.Descendants("div")
    .Where(node => node.GetAttributeValue("data-testid", "product-card")
    .Equals("product-card")).ToList();

foreach (var produto in produtos)
{
    var nome = produto.Descendants("h2")
        .FirstOrDefault()?.InnerText.Trim();

    var preco = produto.Descendants("p")
                     .FirstOrDefault(node => node.GetAttributeValue("data-testid", "product-card::price")
                     .Contains("product-card::price"))?.InnerText.Trim();

    if (nome != null && preco != null && !_dict.ContainsKey(nome) && preco != "TV" && !preco.Contains("resultados"))
        _dict.Add(nome, preco);
}

var result = _dict.Distinct();

foreach (var item in result)
{
    Console.WriteLine(item.Key);
    Console.WriteLine(item.Value);
    Console.WriteLine("___________________");
}

Console.ReadKey();
