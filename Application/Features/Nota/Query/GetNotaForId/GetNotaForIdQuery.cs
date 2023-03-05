using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Nota.Query.GetNotaForId
{
    public class GetNotaForIdQuery : IRequest<NotaForIdVm>
    {
        public Guid NotaId { get; set; }
    }
}
