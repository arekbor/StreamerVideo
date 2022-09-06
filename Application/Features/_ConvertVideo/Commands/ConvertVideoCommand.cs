using MediatR;
using VideoLibrary;
using Domain.Entities;

namespace Application.Features.ConvertVideo.Commands;

public class ConvertVideoCommand
    : ConvertVideo<YouTubeVideo>, IRequest
{ }