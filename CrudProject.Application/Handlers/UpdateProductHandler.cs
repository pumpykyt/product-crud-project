using AutoMapper;
using CrudProject.Application.Commands;
using CrudProject.Data.Entities;
using CrudProject.Domain.Interfaces;
using CrudProject.Dto.Requests;
using MediatR;

namespace CrudProject.Application.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken) =>
        await _service.UpdateProductAsync(_mapper.Map<ProductUpdateRequest, Product>(request.Data));
}