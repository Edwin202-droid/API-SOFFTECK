using Application.Features.Representante.Command.GestionRepresentante;
using Application.Features.Representante.Query.GetRepresentanteForEmpresaId;
using Application.Features.Representante.Query.GetRepresentantePaginado;
using Data;
using DTO;
using Helpers.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Softtek_API.Controllers
{
    [ApiController]
    public class RepresentanteController  : ControllerBase
    {
        private readonly SoftteckContext context;
        private readonly IMediator mediator;

        public RepresentanteController(SoftteckContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }


        [HttpPost]
        [Route("GestionRepresentante")]
        public async Task<ActionResult> GestionRepresentante([FromBody] GestionRepresentanteCommand representante)
        {
            var response = await mediator.Send(representante);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Mensaje);
            }
        }

        [HttpPost("RepresentantePaginado")]
        public async Task<ActionResult<List<RepresentantePaginado>>> GetEmpresaPaginado([FromBody] FiltroPaginado filtro)
        {
            var page = new PagedRequest
            {
                PageNumber = filtro.NumeroPagina,
                PageSize = 10
            };

            var request = new GetRepresentantePaginadoQuery
            {
                Page = page
            };
            var response = await mediator.Send(request);

            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(response.paging));
            return Ok(response.records);
        }

        [HttpGet("GetRepresentantes")]
        public async Task<ActionResult<List<RepresentanteVm>>> GetRepresentantes(Guid empresaId)
        {
            var response = await mediator.Send(new GetRepresentanteQuery {  EmpresaId = empresaId});
            return Ok(response);
        }
    }
}
