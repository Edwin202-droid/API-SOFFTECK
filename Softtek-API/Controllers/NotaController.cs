using Application.Features.Nota.Command.CreateNota;
using Application.Features.Nota.Query.GetNotaForId;
using Application.Features.Nota.Query.GetNotas;
using Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Softtek_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly SoftteckContext context;
        private readonly IMediator mediator;

        public NotaController(SoftteckContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("CreateNota")]
        public async Task<ActionResult> CreateNota([FromBody] CreateNotaCommand nota)
        {
            var response = await mediator.Send(nota);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Mensaje);
            }
        }

        [HttpGet]
        [Route("GetNotas/{id}")]
        public async Task<ActionResult<List<NotasVm>>> GetNotas(string id)
        {
            var response = await mediator.Send(new GetNotaQuery { UserId = id });
            return Ok(response);
        }

        [HttpGet]
        [Route("GetNotaForId/{id}")]
        public async Task<ActionResult<NotaForIdVm>> GetNotaForId(Guid id)
        {
            var response = await mediator.Send(new GetNotaForIdQuery { NotaId = id });
            return Ok(response);
        }
    }
}
