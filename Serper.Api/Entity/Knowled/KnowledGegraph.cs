namespace Serper.API.Entity.Knowled
{
    public sealed class KnowledGegraph
    {
        public string title { get; set; }

        public string type { get; set; }

        public string website { get; set; }

        public string imageUrl { get; set; }

        public string description { get; set; }

        public string descriptionSource { get; set; }

        public string descriptionLink { get; set; }

        public Attributes attributes { get; set; }
    }
}