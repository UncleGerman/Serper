namespace Serper.BLL.Entity
{
    public sealed class SearchResultDTO
    {
        public int Position { get; set; }

        public string? Query { get; set; }

        public string? Link { get; set; }

        public Guid UserId { get; set; }
    }
}