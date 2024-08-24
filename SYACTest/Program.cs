using Microsoft.EntityFrameworkCore;
using SYACTest.AppDbContext;
using SYACTest.Services.Clients;
using SYACTest.Services.ProductsServices;
using SYACTest.Services.PurchesOrderService;

var builder = WebApplication.CreateBuilder(args);
var Connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Connection));
builder.Services.AddControllers();
builder.Services.AddScoped<IPurchesOrderService, PurchesOrderService>();
builder.Services.AddScoped<IProductService, Productservices>();
builder.Services.AddScoped<IClientsService, ClientsService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
