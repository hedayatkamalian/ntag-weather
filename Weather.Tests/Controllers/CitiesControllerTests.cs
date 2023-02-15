using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Weather.App.DTO;
using Weather.App.Options;
using Weather.App.Services.Interfaces;
using Weather.Controllers;

namespace Weather.Tests.Controllers;

public class CitiesControllerTests
{
    private readonly IOptions<ApplicationOptions> _applicationOptionMock;
    private Fixture _fixture { get { return new Fixture(); } }

    public CitiesControllerTests()
    {

        _applicationOptionMock = Options.Create(new ApplicationOptions());
        _applicationOptionMock.Value.SearchQueryMinLength = 3;

    }

    [Fact]
    public void GetByName_Should_Return_UnprocessableEnity_When_Query_Is_Empty()
    {
        var citiesServiceMock = new Mock<ICitiesService>();
        var controller = new CitiesController(citiesServiceMock.Object, _applicationOptionMock);

        var result = controller.GetByName("", _fixture.Create<CancellationToken>());
        result.Should().BeOfType<UnprocessableEntityResult>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("ab")]
    public void GetByName_Should_Return_UnprocessableEnity_When_Query_Is_Less_Than_MinQueryLength(string query)
    {
        var citiesServiceMock = new Mock<ICitiesService>();
        var controller = new CitiesController(citiesServiceMock.Object, _applicationOptionMock);

        var result = controller.GetByName(query, _fixture.Create<CancellationToken>());
        result.Should().BeOfType<UnprocessableEntityResult>();
    }

    [Fact]
    public void GetByName_Should_Return_Ok_When_CitiesService_Has_Result()
    {
        var citiesServiceMock = new Mock<ICitiesService>();
        citiesServiceMock.Setup(p => p.SearchCityByName(It.IsAny<string>())).Returns(_fixture.Create<IList<CitySearchResultItem>>());
        var controller = new CitiesController(citiesServiceMock.Object, _applicationOptionMock);

        var result = controller.GetByName("query", _fixture.Create<CancellationToken>());
        result.Should().BeOfType<OkObjectResult>();
    }

}
