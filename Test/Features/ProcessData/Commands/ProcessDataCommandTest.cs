using Application.Features.ProcessDataFeatures.Commands;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace Test.Features.ProcessData.Commands;

public class ProcessDataCommandTest
{
    private readonly ProcessDataCommandHandler _handler;

    public ProcessDataCommandTest()
    {
        _handler = new ProcessDataCommandHandler
            (new Mock<IMediator>().Object);
    }
    [Fact]
    public async Task ProcessData_ValidationErrors_Count_ShouldBe_0() {

        var command = new ProcessDataCommand() {
            SteamId = "33255434565",
            Rank = "12",
            Token = "33311123331",
            YoutubeUrl = "https://www.youtube.com/watch?v=NQ3fZtyXji0"
        };
        var response = await _handler.Handle(command, CancellationToken.None);
        response.ValidationErrors.Count().ShouldBe(0);
    }
    [Theory]
    [InlineData("-500")]
    [InlineData("0")]
    [InlineData("13")]
    [InlineData("500")]
    public async Task ProcessData_Rank_ValidationErrors_Count_ShouldBe_1(string rank) {
        var command = new ProcessDataCommand() {
            SteamId = "33255434565",
            Rank = rank,
            Token = "33311123331",
            YoutubeUrl = "https://www.youtube.com/watch?v=NQ3fZtyXji0"
        };
        var response = await _handler.Handle(command, CancellationToken.None);

        response.ValidationErrors.Count().ShouldBe(1);
    }
    [Theory]
    [InlineData("test123123123123123")]
    [InlineData("1111111111111111111111111111111")]
    [InlineData("test")]
    public async Task ProcessData_Steamid_ValidationErrors_Count_ShouldBe_1(string steamId) {
        var command = new ProcessDataCommand(){
            SteamId = steamId,
            Rank = "12",
            Token = "33311123331",
            YoutubeUrl = "https://www.youtube.com/watch?v=NQ3fZtyXji0"
        };
        var response = await _handler.Handle(command, CancellationToken.None);

        response.ValidationErrors.Count().ShouldBe(1);
    }
    [Theory]
    [InlineData("test123123123123123")]
    [InlineData("1111111111111111111111111111111")]
    [InlineData("test")]
    public async Task ProcessData_Token_ValidationErrors_Count_ShouldBe_1(string token)
    {
        var command = new ProcessDataCommand(){
            SteamId = "33255434565",
            Rank = "12",
            Token = token,
            YoutubeUrl = "https://www.youtube.com/watch?v=NQ3fZtyXji0"
        };
        var response = await _handler.Handle(command, CancellationToken.None);

        response.ValidationErrors.Count().ShouldBe(1);
    }
}