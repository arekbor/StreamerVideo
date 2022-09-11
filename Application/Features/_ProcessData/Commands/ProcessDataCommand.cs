using Domain.Models;
using MediatR;

namespace Application.Features._ProcessData.Commands;

public class ProcessDataCommand
    : ProcessData, IRequest<ProcessDataCommandResponse>
{ 
}