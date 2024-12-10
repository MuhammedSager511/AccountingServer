//using AccountingServer.Application;
//using AccountingServer.Infrastructure;
//using AccountingServer.WebAPI.Middlewares;
//using DefaultCorsPolicyNugetPackage;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.OpenApi.Models;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDefaultCors();
//builder.Services.AddApplication();
//builder.Services.AddInfrastructure(builder.Configuration);

//builder.Services.AddExceptionHandler<ExceptionHandler>();
//builder.Services.AddProblemDetails();

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(setup =>
//{
//    var jwtSecuritySheme = new OpenApiSecurityScheme
//    {
//        BearerFormat = "JWT",
//        Name = "JWT Authentication",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = JwtBearerDefaults.AuthenticationScheme,
//        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

//        Reference = new OpenApiReference
//        {
//            Id = JwtBearerDefaults.AuthenticationScheme,
//            Type = ReferenceType.SecurityScheme
//        }
//    };

//    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

//    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                    { jwtSecuritySheme, Array.Empty<string>() }
//                });
//});

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseCors();

//app.UseExceptionHandler();

//app.MapControllers();

//ExtensionsMiddleware.CreateFirstUser(app);

//app.Run();


using AccountingServer.Application;
using AccountingServer.Infrastructure;
using AccountingServer.WebAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ≈⁄œ«œ ”Ì«”… CORS „Œ’’…
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // «·”„«Õ »„’œ— Angular
              .AllowAnyHeader()                     // «·”„«Õ »√Ì  —ÊÌ”…
              .AllowAnyMethod();                    // «·”„«Õ »√Ì ÿ—Ìﬁ… (GET, POST, ≈·Œ)
    });
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token in the textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//  ÿ»Ìﬁ ”Ì«”… CORS
app.UseCors(policy => policy
    .WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod());


app.UseExceptionHandler();

app.MapControllers();

ExtensionsMiddleware.CreateFirstUser(app);

app.Run();
