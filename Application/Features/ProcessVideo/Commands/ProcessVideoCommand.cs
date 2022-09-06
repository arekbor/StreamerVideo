using MediatR;

namespace Application.Features.ProcessVideo.Commands;

public class ProcessVideoCommand
    : ProcessVideoCommandDto, IRequest<ProcessVideoCommandResponse>
{ }