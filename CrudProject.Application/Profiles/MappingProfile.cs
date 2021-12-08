using AutoMapper;
using CrudProject.Application.Commands;
using CrudProject.Data.Entities;
using CrudProject.Dto.Requests;
using CrudProject.Dto.Responses;

namespace CrudProject.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductCreateRequest, Product>();
        CreateMap<ProductUpdateRequest, Product>();
        CreateMap<Product, ProductResponse>();
    }
}