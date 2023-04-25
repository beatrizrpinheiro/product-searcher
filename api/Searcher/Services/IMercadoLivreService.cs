using Searcher.Models;

namespace Searcher.Services
{
    public interface IMercadoLivreService
    {
        List<Product> SearchProductsMercadoLivre(string categoria);
    }
}
