using Application.Features._ConvertVideo.Commands;
using Shouldly;
using VideoLibrary;
using Xunit;

namespace Test.Features._ConvertVideo
{
    public class ConvertVideoCommandTest
    {
        private readonly ConvertVideoCommandHandler _handler;
        private const string _pathTest = "F:/pobrane/";
        public ConvertVideoCommandTest()
        {
            _handler = new ConvertVideoCommandHandler();
        }
        [Fact]
        public async Task ConvertVideo_ValidationErrors_Count_ShouldBe_0() {
            //video lenght 2:58
            var video = await YouTube.Default.GetVideoAsync("https://www.youtube.com/watch?v=9Nsbbcn10rk");

            var command = new ConvertVideoCommand() {
                Video = video,
                PathToSaveVideo = _pathTest
            };
            var result = await _handler.Handle(command, CancellationToken.None);

            result.ValidationErrors.Count().ShouldBe(0);

            foreach (var file in Directory.GetFiles(_pathTest))
            {
                File.Delete(file);
            }
        }
        [Fact]
        public async Task ConvertVideo_ValidationErrors_Too_Long_Video_Count_ShouldBe_1() {
            //video lenght 58:55
            var video = await YouTube.Default.GetVideoAsync("https://youtu.be/M0tCs1twYsU");
            var command = new ConvertVideoCommand()
            {
                Video = video,
                PathToSaveVideo = _pathTest
            };
            var result = await _handler.Handle(command, CancellationToken.None);

            result.ValidationErrors.Count().ShouldBe(1);

            foreach (var file in Directory.GetFiles(_pathTest))
            {
                File.Delete(file);
            }
        }

    }
}
