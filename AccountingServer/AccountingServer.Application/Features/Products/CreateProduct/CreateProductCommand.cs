using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Products.CreateProduct;
public sealed record CreateProductCommand(
    string Name) : IRequest<Result<string>>;
