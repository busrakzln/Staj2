using Microsoft.EntityFrameworkCore;
using Staj2Proje.Data; // DbContext'in bulunduğu namespace
using Microsoft.Extensions.DependencyInjection;
using Staj2Proje.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Connection string'i ayarlama

// Add your services (Dependency Injection)
builder.Services.AddScoped<IInvoiceService, InvoiceService>();   // Example for Invoice Service
builder.Services.AddScoped<IFaultService, FaultService>();       // Example for Fault Service
builder.Services.AddScoped<IOutageService, OutageService>();     // Example for Outage Service
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
