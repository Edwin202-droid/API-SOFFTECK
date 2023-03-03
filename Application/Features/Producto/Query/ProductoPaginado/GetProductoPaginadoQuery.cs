using Application.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Producto.Query.ProductoPaginado
{
    public class GetProductoPaginadoQuery : BaseRequest, IRequest<ResultProductoPaginado>
    {
    }
}
