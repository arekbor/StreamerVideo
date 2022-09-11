using MediatR;
using VideoLibrary;

namespace Application.Events._ProcessData;

public class ProcessedDataEvent
    : INotification
{
    public YouTubeVideo YouTubeVideo { get; set; }
}