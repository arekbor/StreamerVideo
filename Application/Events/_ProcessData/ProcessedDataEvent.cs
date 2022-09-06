using MediatR;
using VideoLibrary;

namespace Application.Events.ProcessData;

public class ProcessedDataEvent
    :INotification
{
    public YouTubeVideo YouTubeVideo { get; set; }
}