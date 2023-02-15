using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Weather.App.Options;
using Weather.App.Services.Interfaces;
using Weather.Controllers;
using Xunit;

namespace Weather.Test.Controllers;

public class CitiesControllerTests
{
    private readonly CitiesController _controller;
    private Fixture _fixture { get { return new Fixture(); } }

    public CitiesControllerTests()
    {

        var applicationOptionMock = new Mock<IOptions<ApplicationOptions>>();
        applicationOptionMock.SetupProperty(p => p.Value.SearchQueryMinLength, 3);

        var citiesServiceMock = new Mock<ICitiesService>();

        _controller = new CitiesController(citiesServiceMock.Object, applicationOptionMock.Object);

    }

    [Fact]
    public void GetByName_Should_Return_UnprocessableEnity_When_QueryIsEmpty()
    {
        var result = _controller.GetByName("", _fixture.Create<CancellationToken>());
        result.Should().BeOfType<UnprocessableEntityObjectResult>();
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    public void GetByName_Should_Return_UnprocessableEnity_When_Query_Is_Less_Than_MinQueryLength(string query)
    {
        var result = _controller.GetByName(query, _fixture.Create<CancellationToken>());
        result.Should().BeOfType<UnprocessableEntityObjectResult>();
    }
}
