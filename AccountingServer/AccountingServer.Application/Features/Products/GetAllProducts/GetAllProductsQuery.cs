using AccountingServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace AccountingServer.Application.Features.Products.GetAllProducts;
public sealed record GetAllProductsQuery() : IRequest<Result<List<Product>>>;
