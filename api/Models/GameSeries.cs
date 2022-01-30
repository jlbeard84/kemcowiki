namespace api.Models
{
    public class GameSeries
    {
        public string Id { get; set; } = string.Empty;
        
        public string SeriesName { get; set; } = string.Empty;
        
        public List<Game>? SeriesGames { get; set; }
    }
}