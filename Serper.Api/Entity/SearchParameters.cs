namespace Serper.API.Entity
{
    public sealed class SearchParameters
    {
        public string q { get; set; }

        public string gl { get; set; }

        public string hl { get; set; }

        public bool autocorrect { get; set; }

        public int page { get; set; }

        public string type { get; set; }
    }
}