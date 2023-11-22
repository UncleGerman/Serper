namespace Serper.API.Entity
{
    public sealed class RootObject
    {
        public SearchParameters? SearchParameters { get; set; }

        public ICollection<Organic>? Organic { get; set; }
    }
}