using Searcher.Models;

namespace Searcher.Services
{
    public interface IBuscapeService
    {
        List<Product> SearchProducts(string categoria, int page);
    }
}
