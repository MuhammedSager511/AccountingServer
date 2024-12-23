using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace AccountingServer.Application.Features.ProductDetails.GetAllProductDetails;

internal sealed class GetAllProductDetailsQueryHandler(
    IProductRepository productRepository) : IRequestHandler<GetAllProductDetailsQuery, Result<Product>>
{
    public async Task<Result<Product>> Handle(GetAllProductDetailsQuery request, CancellationToken cancellationToken)
    {
        Product? product = 
            await productRepository
            .Where(p => p.Id == request.ProductId)
            .Include(p => p.Details)
            .FirstOrDefaultAsync(cancellationToken);

        if(product is null)
        {
            return Result<Product>.Failure("No product found");
        }

        return product;
    }
}
