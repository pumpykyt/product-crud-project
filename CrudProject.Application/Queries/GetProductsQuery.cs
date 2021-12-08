using CrudProject.Data.Entities;
using CrudProject.Dto.Responses;
using MediatR;

namespace CrudProject.Application.Queries;

public class GetProductsQuery : IRequest<IEnumerable<ProductResponse>>
{
    
}