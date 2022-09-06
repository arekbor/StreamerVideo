using Domain;
using MediatR;

namespace Application.Features.ProcessDataFeatures.Commands;

public class ProcessDataCommand
    : ProcessData, IRequest<ProcessDataCommandResponse>
{ 
}