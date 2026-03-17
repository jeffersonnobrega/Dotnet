using AutoMapper;
using Atendimento.Domain.DTOs;
using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Departamentos, DepartamentoResponseDto>();
            CreateMap<DepartamentoCreateDto, Departamentos>();
            // CreateMap<Departamentos, DepartamentoListaDto>();
        }
    }
}