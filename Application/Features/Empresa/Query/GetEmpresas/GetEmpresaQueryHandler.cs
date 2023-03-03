using AutoMapper;
using Data.Repositories_Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Empresa.Query.GetEmpresas
{
    public class GetEmpresaQueryHandler : IRequestHandler<GetEmpresaQuery, List<GetEmpresa>>
    {
        private readonly IEmpresaRepository empresaRepository;
        private readonly IMapper mapper;

        public GetEmpresaQueryHandler(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            this.empresaRepository = empresaRepository;
            this.mapper = mapper;
        }
        public async Task<List<GetEmpresa>> Handle(GetEmpresaQuery request, CancellationToken cancellationToken)
        {
            var empresas = await empresaRepository.ListAllAsync();
            return mapper.Map<List<GetEmpresa>>(empresas);
        }
    }
}
