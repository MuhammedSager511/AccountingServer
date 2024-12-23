using AccountingServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.ProductDetails.GetAllProductDetails;
public sealed record GetAllProductDetailsQuery(
    Guid ProductId) : IRequest<Result<Product>>;
