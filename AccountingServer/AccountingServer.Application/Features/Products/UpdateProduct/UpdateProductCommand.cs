using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Products.UpdateProduct;
public sealed record UpdateProductCommand(
    Guid Id,
    string Name) : IRequest<Result<string>>;
