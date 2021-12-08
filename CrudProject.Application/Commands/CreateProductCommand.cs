using CrudProject.Dto.Requests;
using MediatR;

namespace CrudProject.Application.Commands;

public class CreateProductCommand : IRequest<bool>
{
    public ProductCreateRequest Data { get; set; }

    public CreateProductCommand(ProductCreateRequest data) => Data = data;
}