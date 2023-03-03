using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Nota.Query.GetNotas
{
    public class GetNotaQuery : IRequest<List<NotasVm>>
    {
    }
}
