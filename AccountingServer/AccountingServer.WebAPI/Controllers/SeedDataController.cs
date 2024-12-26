using Bogus;
using AccountingServer.Application.Features.Customers.CreateCustomer;
using AccountingServer.Application.Features.Customers.GetAllCustomers;
using AccountingServer.Application.Features.Invoices.CreateInvoice;
using AccountingServer.Application.Features.Products.CreateProduct;
using AccountingServer.Application.Features.Products.GetAllProducts;
using AccountingServer.Domain.Dtos;
using AccountingServer.Domain.Entities;
using AccountingServer.Domain.Enums;
using AccountingServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TS.Result;

namespace AccountingServer.WebAPI.Controllers;

public sealed class SeedDataController : ApiController
{    
    public SeedDataController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        Random random = new Random();

        //Customers
        //for (int i = 0; i < 100; i++)
        //{
        //    Faker faker = new();
        //    int customerTypeValue = random.Next(1, 5);
        //    CreateCustomerCommand customer = new(
        //        faker.Company.CompanyName(),
        //        customerTypeValue,
        //        faker.Address.City(),
        //        faker.Address.State(),
        //        faker.Address.FullAddress(),
        //        faker.Company.Random.String2(random.Next(10, 25)),
        //        faker.Company.Random.ULong(1111111111, 99999999999).ToString());

        //    await _mediator.Send(customer);
        //}

        ////Products
        //for (int i = 0; i < 1000; i++)
        //{
        //    Faker faker = new();
        //    CreateProductCommand product = new(
        //        faker.Commerce.ProductName());

        //    await _mediator.Send(product);
        //}

        //Invoices
        var customersResult = await _mediator.Send(new GetAllCustomersQuery());
        var customers = customersResult.Data;

        var productsResult = await _mediator.Send(new GetAllProductsQuery());
        var products = productsResult.Data?.Where(p => p.Withdrawal > 0).ToList();

        // تحقق من القوائم
        if (customers == null || !customers.Any())
        {
            return BadRequest("No customers available for seeding invoices.");
        }

        if (products == null || !products.Any())
        {
            return BadRequest("No products available for seeding invoices.");
        }

  

        for (int i = 0; i < 100; i++)
        {
            Faker faker = new();

            List<InvoiceDetailDto> invoiceDetails = new();
            for (int x = 0; x < random.Next(1, 11); x++)
            {
                // توليد فهرس عشوائي صحيح
                int productIndex = random.Next(0, products.Count);
                InvoiceDetailDto invoiceDetailDto = new()
                {
                    ProductId = products[productIndex].Id,
                    Price = random.Next(1, 1000),
                    Quantity = random.Next(1, 100)
                };

                invoiceDetails.Add(invoiceDetailDto);
            }

            // توليد فهرس عشوائي صحيح
            int customerIndex = random.Next(0, customers.Count);
            CreateInvoiceCommand invoice = new(
                1,
                new DateOnly(2024, random.Next(1, 13), random.Next(1, 29)),
                faker.Random.ULong(3, 16).ToString(),
                customers[customerIndex].Id,
                invoiceDetails
            );

            await _mediator.Send(invoice);
        }


        return Ok(Result<string>.Succeed("Seed data created successfully"));
    }
}
