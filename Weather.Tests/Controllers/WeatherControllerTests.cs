using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Weather.App.DTO;
using Weather.App.Services.Interfaces;
using Weather.Controllers;

namespace Weather.Tests.Controllers;

public class WeatherControllerTests
{
    private Fixture _fixture { get { return new Fixture(); } }

    public WeatherControllerTests() { }

    [Fact]
    public async Task GetWeatherByCityID_Should_Return_NotFound_When_Service_Result_Is_Null()
    {
        var weatherServiceMock = new Mock<IWeatherService>();
        weatherServiceMock.Setup(p => p.GetWeatherByCityId(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(null as WeatherResponse);
        var controller = new WeatherController(weatherServiceMock.Object);


        var result = await controller.GetByCityId(_fixture.Create<int>(), _fixture.Create<CancellationToken>());
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task GetWeatherByCityID_Should_Return_Ok_When_WeatherService_Result_Is_Not_Null()
    {
        var weatherServiceMock = new Mock<IWeatherService>();
        weatherServiceMock.Setup(p => p.GetWeatherByCityId(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<WeatherResponse>());
        var controller = new WeatherController(weatherServiceMock.Object);


        var result = await controller.GetByCityId(_fixture.Create<int>(), _fixture.Create<CancellationToken>());
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task GetWeatherByLocation_Should_Return_NotFound_When_WeatherService_Result_Is_Null()
    {
        var weatherServiceMock = new Mock<IWeatherService>();
        weatherServiceMock.Setup(p => p.GetWeatherFromOpenWeatherByLocation(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<CancellationToken>())).ReturnsAsync(null as WeatherResponse);
        var controller = new WeatherController(weatherServiceMock.Object);


        var result = await controller.GetByLocation(_fixture.Create<double>(), _fixture.Create<double>(), _fixture.Create<CancellationToken>());
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task GetWeatherByLocation_Should_Return_Ok_When_WeatherService_Result_Is_Not_Null()
    {
        var weatherServiceMock = new Mock<IWeatherService>();
        weatherServiceMock.Setup(p => p.GetWeatherFromOpenWeatherByLocation(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Create<WeatherResponse>());
        var controller = new WeatherController(weatherServiceMock.Object);


        var result = await controller.GetByLocation(_fixture.Create<double>(), _fixture.Create<double>(), _fixture.Create<CancellationToken>());
        result.Should().BeOfType<OkObjectResult>();

    }



}
