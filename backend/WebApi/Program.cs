using Application;
using Infrastructure.Persistence;
using Infrastructure.Shared;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Context application
// builder.Services.AddDbContext<AppDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//
builder.Services.AddApplicationLayer();
// inject dependencies
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddSharedInfrastructure(builder.Configuration);

builder.Services.AddSwaggerExtension();
builder.Services.AddControllersExtension();
// CORS
builder.Services.AddCorsExtension();
builder.Services.AddHealthChecks();
// API version
builder.Services.AddApiVersioningExtension();
// API explorer
builder.Services.AddMvcCore().AddApiExplorer();
// API explorer version
builder.Services.AddVersionedApiExplorerExtension();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerExtension();
}

// app.UseSerilogRequestLogging();
app.UseRouting();

// Enable CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorHandlingMiddleware();
app.UseHealthChecks("/health");

app.MapControllers();

app.Run();