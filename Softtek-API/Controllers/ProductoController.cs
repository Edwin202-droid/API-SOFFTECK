using Application.Features.Producto.Command.GestionProducto;
using Application.Features.Producto.Query.ProductoPaginado;
using Data;
using DTO;
using Helpers.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Softtek_API.Controllers
{
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly SoftteckContext context;
        private readonly IMediator mediator;

        public ProductoController(SoftteckContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("GestionProducto")]
        public async Task<ActionResult> GestionProducto([FromBody] GestionProductoCommand producto)
        {
            var response = await mediator.Send(producto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Mensaje);
            }
        }

        [HttpPost("ProductoPaginado")]
        public async Task<ActionResult<List<ProductoPaginadoVm>>> GetProductoPaginado([FromBody] FiltroPaginado filtro)
        {
            var page = new PagedRequest
            {
                PageNumber = filtro.NumeroPagina,
                PageSize = 10
            };

            var request = new GetProductoPaginadoQuery
            {
                Page = page
            };
            var response = await mediator.Send(request);

            HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(response.paging));
            return Ok(response.records);
        }
    }
}
