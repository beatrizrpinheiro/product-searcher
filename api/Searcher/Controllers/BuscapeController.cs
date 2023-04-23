using Microsoft.AspNetCore.Mvc;
using Searcher.Services;

namespace Searcher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuscapeController : ControllerBase
    {
        private readonly IBuscapeService _buscapeService;

        public BuscapeController(IBuscapeService buscapeService)
        {
            _buscapeService = buscapeService;
        }

        [HttpGet("products")]
        public IActionResult GetProducts(string categoria, int page)
        {
            var produtos = _buscapeService.SearchProducts(categoria, page);
            return Ok(produtos);
        }
    }
}
