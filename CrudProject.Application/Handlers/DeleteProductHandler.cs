using AutoMapper;
using CrudProject.Application.Commands;
using CrudProject.Domain.Interfaces;
using MediatR;

namespace CrudProject.Application.Handlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductService _service;

    public DeleteProductHandler(IProductService service) => _service = service;

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken) =>
        await _service.DeleteProductAsync(request.ProductId);
}