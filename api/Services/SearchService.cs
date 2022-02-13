using api.Interfaces;
using api.Models;
using Microsoft.Azure.Cosmos;

namespace api.Services
{
    public class SearchService : DBService, ISearchService
    {
        private const string EnglishCharacterPattern = @"([A-Za-z])+";

        public SearchService(
            IApiSettings settings,
            CosmosClient cosmosClient)
            : base (settings, cosmosClient)
        { }

        public async Task<List<SearchResult>> Search(
            string query,
            string searchType)
        {
            var results = new List<SearchResult>();

            switch (searchType.ToLower().Trim())
            {
                case "game":
                    results = await SearchGames(query);
                    break;
                case "staff":
                    results = await SearchStaff(query);
                    break;
                case "series":
                    results = await SearchSeries(query);
                    break;
                case "any":
                    results = await SearchAny(query);
                    break;
                default:
                    break;
            }

            return results;
        }

        private async Task<List<SearchResult>> SearchGames(
            string query)
        {
            return new List<SearchResult>();
        }

        private async Task<List<SearchResult>> SearchStaff(
            string query)
        {
            return new List<SearchResult>();
        }

        private async Task<List<SearchResult>> SearchSeries(
            string query)
        {
            return new List<SearchResult>();
        }

        private async Task<List<SearchResult>> SearchAny(
            string query)
        {
            return new List<SearchResult>();
        }
        
        private QueryDefinition GetSearchQueryDefinition(
            string containerName,
            List<KeyValuePair<string, string>> queryParameters)
        {
            var queryString = $"SELECT * FROM {containerName} WHERE ";
            var queryValues = new List<string>();

            foreach (var queryParameter in queryParameters)
            {
                queryValues.Add($"{containerName}.{queryParameter.Key}=@{queryParameter.Key}");
            }

            queryString = $"{queryString}{string.Join(" OR ", queryValues)}";

            var queryDefinition = new QueryDefinition(queryString);

            foreach (var queryParameter in queryParameters)
            {
                queryDefinition = queryDefinition
                    .WithParameter($"@{queryParameter.Key}", queryParameter.Value);
            }

            return queryDefinition;
        }
    }
}