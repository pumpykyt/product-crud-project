using AutoMapper;
using CrudProject.Application.Commands;
using CrudProject.Data.Entities;
using CrudProject.Domain.Interfaces;
using CrudProject.Dto.Requests;
using MediatR;

namespace CrudProject.Application.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public CreateProductHandler(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken) => 
        await _service.CreateProductAsync(_mapper.Map<ProductCreateRequest, Product>(request.Data));
}