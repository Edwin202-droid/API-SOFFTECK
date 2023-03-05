using AutoMapper;
using Data.Repositories_Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Nota.Query.GetNotaForId
{
    public class GetNotaForIdQueryHandler : IRequestHandler<GetNotaForIdQuery, NotaForIdVm>
    {
        private readonly INotaRepository notaRepository;
        private readonly IMapper mapper;

        public GetNotaForIdQueryHandler(INotaRepository notaRepository, IMapper mapper)
        {
            this.notaRepository = notaRepository;
            this.mapper = mapper;
        }
        public async Task<NotaForIdVm> Handle(GetNotaForIdQuery request, CancellationToken cancellationToken)
        {
            var response = new NotaForIdVm();
            var nota = await notaRepository.GetNotaForId(request.NotaId);

            response.Descripcion = nota.Descripcion;
            response.Total = nota.Total;
            response.NombreEmpresa = nota.Empresa.Nombre;
            response.NombreRepresentante = nota.Representante.Nombre;
            response.Telefono = nota.Representante.Telefono;
            response.Detalles = mapper.Map<List<NotaForIdDetalle>>(nota.NotaDetalles);

            return response;

        }
    }
}
