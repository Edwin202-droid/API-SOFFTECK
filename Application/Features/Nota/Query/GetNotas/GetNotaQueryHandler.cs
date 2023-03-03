using AutoMapper;
using Data.Repositories_Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Nota.Query.GetNotas
{
    public class GetNotaQueryHandler : IRequestHandler<GetNotaQuery, List<NotasVm>>
    {
        private readonly INotaRepository notaRepository;
        private readonly IMapper mapper;

        public GetNotaQueryHandler(INotaRepository notaRepository, IMapper mapper)
        {
            this.notaRepository = notaRepository;
            this.mapper = mapper;
        }

        public async Task<List<NotasVm>> Handle(GetNotaQuery request, CancellationToken cancellationToken)
        {
            var notas = await notaRepository.GetNotas();
            return mapper.Map<List<NotasVm>>(notas);
        }
    }
}
