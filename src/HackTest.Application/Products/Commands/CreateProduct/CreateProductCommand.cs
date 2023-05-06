using MediatR;
using HackTest.Domain.Entities;
using HackTest.Application.Common.Interfaces;

namespace HackTest.Application.Products.Commands.CreateProduct;
public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateProductCommandHandler(IApplicationDbContext context) => this._context = context;
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product entity = new()
        {
            Name = request.Name,
            Price = request.Price,
        };
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }
}
