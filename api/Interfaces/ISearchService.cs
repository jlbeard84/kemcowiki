using api.Models;

namespace api.Interfaces
{
    public interface ISearchService
    {
        Task<List<SearchResult>> Search(
            string query,
            string searchType);
    }
}