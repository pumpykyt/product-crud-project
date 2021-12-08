using CrudProject.Application.Commands;
using CrudProject.Application.Queries;
using CrudProject.Dto.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudProject.Web.Controllers;

public sealed class ProductController : ApiControllerBase
{
    public ProductController(ISender mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(ProductCreateRequest model) =>
        await Mediator.Send(new CreateProductCommand(model)) ? Ok() : BadRequest();

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync(ProductUpdateRequest model) =>
        await Mediator.Send(new UpdateProductCommand(model)) ? Ok() : NotFound();

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync() => 
        Ok(await Mediator.Send(new GetProductsQuery()));

    [HttpDelete]
    public async Task<IActionResult> DeleteProductAsync(string productId) =>
        await Mediator.Send(new DeleteProductCommand(productId)) ? Ok() : NotFound();
}