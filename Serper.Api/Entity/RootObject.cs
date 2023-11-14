using Serper.API.Entity.Knowled;

namespace Serper.API.Entity
{
    public sealed class RootObject
    {
        public SearchParameters searchParameters { get; set; }
        public KnowledGegraph knowledgeGraph { get; set; }
        public Organic[] organic { get; set; }
    }
}