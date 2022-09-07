using Application.Features._ProcessData.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConverterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ConvertVideo(string steamId, string rank, string token, string youtubeUrl) {
            var command = new ProcessDataCommand() {
                Rank = rank,
                Token = token,
                YoutubeUrl = youtubeUrl,
                SteamId = steamId
            };
            var result =  await _mediator.Send(command);
            return Ok(result); 
        }
    }
}
