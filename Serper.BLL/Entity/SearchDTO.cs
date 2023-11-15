namespace Serper.BLL.Entity
{
    public sealed class SearchDTO
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public string Query { get; set; }

        public string DescriptionLink { get; set; }
    }
}