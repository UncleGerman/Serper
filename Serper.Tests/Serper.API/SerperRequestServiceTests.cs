using System.Net;
using Serper.API.Entity;
using Serper.API.Entity.Enums;
using Serper.API.Services;

namespace Serper.Tests.Serper.API
{
    public sealed class SerperRequestServiceTests
    {
        [Fact]
        public void SerperRequestNotNull()
        {
            //Arrange
            var _serperRequestService = new SerperRequestService();

            var _searchRequest = new SearchParameters()
            {
                q = "apple inc",
                gl = Country.us.ToString(),
                hl = Locale.en.ToString(),
                autocorrect = true,
                page = 1,
                type = SearchType.search.ToString(),
            };

            //Act
            var reqest = _serperRequestService.Request(_searchRequest);

            //Assert
            Assert.NotNull(reqest);
        }

        [Fact]
        public void SerperRequestOk()
        {
            //Arrange
            var _serperRequestService = new SerperRequestService();

            var _searchRequest = new SearchParameters()
            {
                q = "apple inc",
                gl = Country.us.ToString(),
                hl = Locale.en.ToString(),
                autocorrect = true,
                page = 1,
                type = SearchType.search.ToString(),
            };

            //Act
            var reqest = _serperRequestService.Request(_searchRequest);

            //Assert
            Assert.Equal(HttpStatusCode.OK, reqest.StatusCode);
        }

        [Fact]
        public void SerperRequestValueIsOK()
        {

        }
    }
}