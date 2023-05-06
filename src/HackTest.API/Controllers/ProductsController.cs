using HackTest.Application.Products.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackTest.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    readonly IMediator _mediator;
    public ProductsController(IMediator mediator) => this._mediator = mediator;
    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommand command)
    {
        await _mediator.Send(command);
        return Ok(command);
    }
}
