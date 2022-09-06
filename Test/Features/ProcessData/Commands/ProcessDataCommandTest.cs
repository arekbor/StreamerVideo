using Application.Features.ProcessData.Commands;
using Shouldly;
using Xunit;

namespace Test.Features.ProcessData.Commands;

public class ProcessDataCommandTest
{
    private readonly ProcessDataCommandHandler _handler = new ProcessDataCommandHandler();
    [Fact]
    public async Task ProcessData_ValidationErrors_ShouldBe_0() {

        var command = new ProcessDataCommand() {
            PathToSaveVideo = @"F:/pobrane/",
            SteamId = "33255434565",
            Rank = "12",
            Token = "33311123331",
            YoutubeUrl = "https://www.youtube.com/watch?v=NQ3fZtyXji0"
        };
        var response = await _handler.Handle(command, CancellationToken.None);
        response.ValidationErrors.Count().ShouldBe(0);
    }
    [Theory]
    [InlineData(
        @"F:/test/test2/test3/",
        "111111111111111111111", 
        "15", 
        "123213123123123123213123211231111111111111111111111", 
        "test"
    )]
    public async Task ProcessData_ValidationErrors_ShouldBe_1
        (string path, string steamId, string rank, string token, string youtubeUrl) {

        var command = new ProcessDataCommand() {
            PathToSaveVideo= path,
            SteamId = steamId,
            Rank = rank,
            Token = token,
            YoutubeUrl = youtubeUrl
        };

        var response = await _handler.Handle(command, CancellationToken.None);

        response.ValidationErrors.Count().ShouldBe(5);
    }
}