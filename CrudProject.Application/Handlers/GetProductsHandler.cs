using AutoMapper;
using CrudProject.Application.Queries;
using CrudProject.Data.Entities;
using CrudProject.Domain.Interfaces;
using CrudProject.Dto.Responses;
using MediatR;

namespace CrudProject.Application.Handlers;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public GetProductsHandler(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductResponse>> Handle(GetProductsQuery request, 
                                                           CancellationToken cancellationToken) 
        => _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(await _service.GetProductsAsync());
}