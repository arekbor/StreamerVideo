using MediatR;
using VideoLibrary;
using Domain.Models;

namespace Application.Features._ConvertVideo.Commands;

public class ConvertVideoCommand
    : ConvertVideo<YouTubeVideo>, IRequest<ConvertVideoCommandResponse>
{ }