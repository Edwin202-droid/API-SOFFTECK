using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Empresa.Query.GetEmpresaPaginado;
using Application.Features.Empresa.Query.GetEmpresas;
using Application.Features.Representante.Query.GetRepresentantePaginado;
using AutoMapper;
using Domain.Entities;

namespace Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Empresa, EmpresaPaginado>().ReverseMap();
            CreateMap<Empresa, GetEmpresa>().ReverseMap();

            CreateMap<Representante, RepresentantePaginado>().ForMember(x => x.NombreEmpresa, dto => dto.MapFrom(campo => campo.Empresa.Nombre))
                    .ForMember(x => x.EmpresaId, dto => dto.MapFrom(campo => campo.Empresa.EmpresaId));
        }
    }
}
