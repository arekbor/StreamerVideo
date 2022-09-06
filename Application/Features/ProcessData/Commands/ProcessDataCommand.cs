using MediatR;

namespace Application.Features.ProcessData.Commands;

public class ProcessDataCommand
    : ProcessDataCommandDto, IRequest<ProcessDataCommandResponse>
{ 
    public string PathToSaveVideo { get; set; }
}