using Serper.API.Entity;
using Serper.BLL.Service.Search;
using Serper.DAL.Entity;
using Serper.DAL.EntityFramework;
using Serper.Infrastructure;
using Serper.Infrastructure.Repository.Factory;

namespace Serper.Tests.Serper.ResourceServer.BLL
{
    public class SearchResultServiceTests
    {
        public SearchResultServiceTests()
        {
            _searchResultService = GetInitializedSearchResultService();
        }

        private readonly ISearchResultService _searchResultService;

        private readonly RootObject _rootObject = new()
        {
            SearchParameters = new SearchParameters(),

            Organic = new List<Organic>()
            {
                new Organic()
                {
                    title = "Apple",
                    link = "https://test",
                    position = 1
                },

                new Organic()
                {
                    title = "Apple Inc",
                    link = "https://test",
                    position = 2
                },

                new Organic()
                {
                    title = "Apple Wiki",
                    link = "https://test",
                    position = 3
                },
            }  
        };

        private readonly SearchResult _searchResult = new()
        {
            Id = "testId",
            Query = "Apple"
        };

        private readonly IReadOnlyCollection<SearchResult> _searchResults = new List<SearchResult>()
        {
            new SearchResult(),
            new SearchResult(),
            new SearchResult()
        };

        #region Insert

        [Fact]
        public async Task InsertAsync_InsertEmptyQery_ReturnSuccessFalse()
        {
            var result = await _searchResultService.InsertAsync(_rootObject);

            Assert.False(result.Success);
        }

        [Fact]
        public async Task InsertAsync_InsertEmptyQery_ReturnErrorMessage()
        {
            var result = await _searchResultService.InsertAsync(_rootObject);

            Assert.Equal("Request not found", result.ErrorMessage);
        }

        [Fact]
        public async Task InsertAsync_InsertRootObject_ReturnSuccessTrue()
        {
            _rootObject.SearchParameters.q = "Apple";

            var result = await _searchResultService.InsertAsync(_rootObject);

            Assert.True(result.Success);
            Assert.Null(result.ErrorMessage);
        }

        #endregion


        [Fact]
        public async void GetByIdAsync_GetSearchResult_ReturnObject()
        {
            var searchResult = await _searchResultService.GetByIdAsync(_searchResult.Id);

            Assert.Equal(searchResult.Query, _searchResult.Query);
        }

        [Fact]
        public void GetAll_GetCollectionObjects_ReturnListObjects()
        {
            var searchResults = _searchResultService.GetAll();

            Assert.NotNull(searchResults);
            Assert.Equal(3, searchResults.Count);
        }

        private ISearchResultService GetInitializedSearchResultService()
        {
            #region SearchResultRepository

            var searchResultRepository = new Mock<ISearchResultRepository>();

            searchResultRepository.Setup(r => r.GetByIdAsnyc(_searchResult.Id)).
                ReturnsAsync(_searchResult);

            searchResultRepository.Setup(r => r.GetAll())
                .Returns(_searchResults);

            #endregion

            var repositoryFactoryMock = new Mock<IRepositoryFactory>();

            repositoryFactoryMock.Setup(r => r.GetSearchResultRepository())
                                 .Returns(searchResultRepository.Object);

            var contextMock = new Mock<ApplicationContext>();

            var unitOfWorkMock = new Mock<UnitOfWork>(
                contextMock.Object,
                repositoryFactoryMock.Object);

            #region Mapper

            var applicationProfile = new ApplicationProfile();
            
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(applicationProfile));
            
            var mapper = new Mapper(configuration);

            #endregion

            var searchResultService = new SearchResultService(
                unitOfWorkMock.Object,
                mapper);

            return searchResultService;
        }
    }
}
