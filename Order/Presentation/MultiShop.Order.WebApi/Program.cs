using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<GetAdressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAdressCommandHandler>();
builder.Services.AddScoped<RemoveAdressCommandHandler>();

builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateAdressCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
builder.Services.AddControllers();
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
