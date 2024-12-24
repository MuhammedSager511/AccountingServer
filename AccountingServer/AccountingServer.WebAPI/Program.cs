using DefaultCorsPolicyNugetPackage;
using AccountingServer.Application;
using AccountingServer.Application.Hubs;
using AccountingServer.Infrastructure;
using AccountingServer.WebAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultCors();
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
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

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

app.UseCors();

app.UseExceptionHandler();

app.MapControllers();

ExtensionsMiddleware.CreateFirstUser(app);

app.MapHub<ReportHub>("/report-hub");

app.Run();








////using AccountingServer.Application;
////using AccountingServer.Infrastructure;
////using AccountingServer.WebAPI.Middlewares;
////using DefaultCorsPolicyNugetPackage;
////using Microsoft.AspNetCore.Authentication.JwtBearer;
////using Microsoft.OpenApi.Models;

////var builder = WebApplication.CreateBuilder(args);

////builder.Services.AddDefaultCors();
////builder.Services.AddApplication();
////builder.Services.AddInfrastructure(builder.Configuration);

////builder.Services.AddExceptionHandler<ExceptionHandler>();
////builder.Services.AddProblemDetails();

////builder.Services.AddControllers();
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen(setup =>
////{
////    var jwtSecuritySheme = new OpenApiSecurityScheme
////    {
////        BearerFormat = "JWT",
////        Name = "JWT Authentication",
////        In = ParameterLocation.Header,
////        Type = SecuritySchemeType.Http,
////        Scheme = JwtBearerDefaults.AuthenticationScheme,
////        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

////        Reference = new OpenApiReference
////        {
////            Id = JwtBearerDefaults.AuthenticationScheme,
////            Type = ReferenceType.SecurityScheme
////        }
////    };

////    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

////    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
////                {
////                    { jwtSecuritySheme, Array.Empty<string>() }
////                });
////});

////var app = builder.Build();

////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseHttpsRedirection();

////app.UseCors();

////app.UseExceptionHandler();
////app.UseDeveloperExceptionPage(); // Ýí ÈíÆÉ ÇáÊØæíÑ ÝÞØ


////app.MapControllers();

////ExtensionsMiddleware.CreateFirstUser(app);

////app.Run();

//using AccountingServer.Application;
//using AccountingServer.Infrastructure;
//using AccountingServer.WebAPI.Middlewares;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.OpenApi.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Add Services to the container
//builder.Services.AddApplication();
//builder.Services.AddInfrastructure(builder.Configuration);

//// Add Controllers
//builder.Services.AddControllers();

//// Configure CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("DefaultPolicy", policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});

//// Configure Swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(setup =>
//{
//    var jwtSecurityScheme = new OpenApiSecurityScheme
//    {
//        BearerFormat = "JWT",
//        Name = "JWT Authentication",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = JwtBearerDefaults.AuthenticationScheme,
//        Description = "Put **_ONLY_** your JWT Bearer token on the textbox below!",

//        Reference = new OpenApiReference
//        {
//            Id = JwtBearerDefaults.AuthenticationScheme,
//            Type = ReferenceType.SecurityScheme
//        }
//    };

//    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

//    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        { jwtSecurityScheme, Array.Empty<string>() }
//    });
//});

//var app = builder.Build();

//// Configure Middleware
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//else
//{
//    app.UseExceptionHandler("/error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseCors("DefaultPolicy");

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllers();

//// Custom Middleware: Create Default User
//ExtensionsMiddleware.CreateFirstUser(app);

//app.Run();
