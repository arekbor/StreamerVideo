using MediatR;
using VideoLibrary;
using Domain.Entities;

namespace Application.Features._ConvertVideo.Commands;

public class ConvertVideoCommand
    : ConvertVideo<YouTubeVideo>, IRequest<ConvertVideoCommandResponse>
{ }