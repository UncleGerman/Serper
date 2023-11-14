namespace Serper.DAL.Entity
{
    internal sealed class Search
    {
        public int Id { get; set; }

        public int Position {  get; set; }

        public string Query { get; set; }

        public string DescriptionLink { get; set; }
    }
}