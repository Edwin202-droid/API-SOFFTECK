using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Empresa.Query.GetEmpresaPaginado;
using Application.Features.Empresa.Query.GetEmpresas;
using Application.Features.Nota.Query.GetNotaForId;
using Application.Features.Nota.Query.GetNotas;
using Application.Features.Producto.Query.ProductoPaginado;
using Application.Features.Representante.Query.GetRepresentanteForEmpresaId;
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
            CreateMap<Representante, RepresentanteVm>().ReverseMap();

            CreateMap<Producto, ProductoPaginadoVm>().ReverseMap();


            CreateMap<Nota, NotasVm>().ForMember(x => x.NombreEmpresa, dto => dto.MapFrom(campo => campo.Empresa.Nombre))
                .ForMember(x => x.NombreRepresentante, dto => dto.MapFrom(campo => campo.Representante.Nombre));

            CreateMap<NotaDetalle, NotaForIdDetalle>().ReverseMap();
        }
    }
}
