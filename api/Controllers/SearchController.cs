using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController: ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchService _searchService;

        public SearchController(
            ILogger<SearchController> logger,
            ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string query,
            [FromQuery] string type)
        {
            var result = await _searchService.Search(
                query, 
                type);
                
            return Ok(result);
        }
    }
}