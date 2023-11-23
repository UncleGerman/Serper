using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Serper.Tests")]
[assembly: InternalsVisibleTo("Serper.Web")]
[assembly: InternalsVisibleTo("Serper.BLL")]
[assembly: InternalsVisibleTo("Serper.Infrastructure")]
namespace Serper.API
{
    internal static class RequestSettings
    {
        public const string ServiceUrl = "https://google.serper.dev/";

        public const string ApiKey = "ed874873e922440e48df83309daca59058b9d57c";
    }
}