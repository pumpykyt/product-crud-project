using CrudProject.Dto.Requests;
using MediatR;

namespace CrudProject.Application.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    public ProductUpdateRequest Data { get; set; }

    public UpdateProductCommand(ProductUpdateRequest data) => Data = data;
}