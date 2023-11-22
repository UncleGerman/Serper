using Serper.API.Entity;
using Serper.BLL.Entity;
using Serper.BLL.Service.Search;

namespace Serper.Tests.Serper.ResourceServer
{
    public class SearchRequestControllerTests
    {
        public SearchRequestControllerTests()
        {
            _searchResultService = new Mock<ISearchResultService>();
        }

        private readonly Mock<ISearchResultService> _searchResultService;

        private readonly SearchResultDTO _searchResultDTO = new()
        {
            Query = "Apple"
        };

        #region Insert

        [Fact]
        public async Task InsertAsync_TaskDone_ReturnCreated()
        {
            var searchResultService = new Mock<ISearchResultService>();

            var entityResultDone = new EntityResult()
            {
                Success = true,
                ErrorMessage = null
            };

            searchResultService.Setup(s => s.InsertAsync(It.IsAny<RootObject>()))
                .Returns(Task.FromResult(entityResultDone));

            var searchReqestController = new SearchRequestController(searchResultService.Object);

            var result = await searchReqestController.InsertAsync(new RootObject());

            var okResult = (ObjectResult)result;

            Assert.Equal(201, okResult.StatusCode);
        }

        [Fact]
        public async Task InsertAsync_TaskFailed_ReturnBadReqest()
        {
            var searchResultService = new Mock<ISearchResultService>();

            var entityResultFailed = new EntityResult()
            {
                Success = false,
                ErrorMessage = "Request not found"
            };

            searchResultService.Setup(s => s.InsertAsync(It.IsAny<RootObject>()))
                .Returns(Task.FromResult(entityResultFailed));

            var searchReqestController = new SearchRequestController(searchResultService.Object);

            var result = await searchReqestController.InsertAsync(new RootObject());

            var okResult = (ObjectResult)result;

            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task InsertAsync_PassNullObject_ReturnBadReqest()
        {
            var searchReqestController = new SearchRequestController(_searchResultService.Object);

            var result = await searchReqestController.InsertAsync(null);

            var okResult = (ObjectResult)result;

            Assert.Equal(400, okResult.StatusCode);
        }


        #endregion

        [Fact]
        public async Task GetByIdAsync_TaskDone_ReturnOkObject()
        {
            _searchResultService.Setup(s => s.GetByIdAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(_searchResultDTO));

            var searchReqestController = new SearchRequestController(_searchResultService.Object);

            var result = await searchReqestController.GetByIdAsync("testId");

            var objectResult = (ObjectResult)result;

            var resultValue = objectResult.Value as SearchResultDTO;

            Assert.Equal(_searchResultDTO.Query, resultValue.Query);
            Assert.Equal(200, objectResult.StatusCode);
        }

        [Fact]
        public async Task GetByIdAsync_PassEmptyId_ReturnOkObject()
        {
            var searchReqestController = new SearchRequestController(_searchResultService.Object);

            var result = await searchReqestController.GetByIdAsync("");

            var objectResult = (ObjectResult)result;

            Assert.Equal(400, objectResult.StatusCode);
        }

        [Fact]
        public void GetAll_GetCollection_ReturnOkCollectionObjects()
        {
            var searchResultsDTO = new List<SearchResultDTO>()
            {
                new SearchResultDTO(),
                new SearchResultDTO(),
                new SearchResultDTO()
            };

            _searchResultService.Setup(s => s.GetAll())
                .Returns(searchResultsDTO);

            var searchReqestController = new SearchRequestController(_searchResultService.Object);

            var result = searchReqestController.GetAll();

            var objectResult = (ObjectResult)result;

            var resultValue = objectResult.Value as ICollection<SearchResultDTO>;

            Assert.NotNull(resultValue);
            Assert.Equal(3, resultValue.Count);
        }
    }
}