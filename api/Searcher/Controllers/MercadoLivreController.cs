using Microsoft.AspNetCore.Mvc;
using Searcher.Services;

namespace Searcher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MercadoLivreController : ControllerBase
    {
        private readonly IMercadoLivreService _mercadoLivreService;

        public MercadoLivreController(IMercadoLivreService mercadoLivreService)
        {
            _mercadoLivreService = mercadoLivreService;
        }

        [HttpGet("products")]
        public IActionResult GetProducts(string categoria)
        {
            var produtos = _mercadoLivreService.SearchProductsMercadoLivre(categoria);
            return Ok(produtos);
        }
    }
}
