using AutoMapper;
using DaniloTest.Models.Requests;
using Test.Domain.DTO;

namespace DaniloTest.Models.Mappers
{
    public class ApiToDtoMappingProfile : Profile
    {
        public ApiToDtoMappingProfile()
        {
            CreateMap<LancamentoRequest, LancamentoDTO>();
        }
        
    }
}
