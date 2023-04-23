namespace Searcher.Services
{
    public interface IBuscapeService
    {
        Dictionary<string, string> SearchProducts(string categoria, int page);
    }
}
