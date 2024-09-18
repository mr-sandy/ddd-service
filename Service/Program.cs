using Facade;
using Facade.Resources;
using Persistence;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var orderService = new OrdersService(new OrderRepository());
var ordersResultVisitor = new FacadeResultVisitor<OrderResource>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/orders", (HttpRequest request, CreateOrderResource resource) =>
{
    var result = orderService.CreateOrder(resource, "Sandy");

    return result.Accept(ordersResultVisitor);
})
.WithName("CreateOrder")
.WithOpenApi();

app.MapPost("/orders/{id}/order-lines", (int id, OrderLineResource resource) =>
{
    var result =  orderService.AddOrderLine(id, resource, "Sandy");

    return result.Accept(ordersResultVisitor);
})
.WithName("AddOrderLine")
.WithOpenApi();

app.MapGet("/orders/{id}", (int id) =>
{
    var result =  orderService.GetOrder(id);

    return result.Accept(ordersResultVisitor);
})
.WithName("GetOrder")
.WithOpenApi();

app.Run();
