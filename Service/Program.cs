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

Func<HttpRequest, string> getUserIdFromHttpRequest = (request) => "Sandy";

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/orders", (HttpRequest request, CreateOrderResource resource) =>
{
    var userId = getUserIdFromHttpRequest(request);
    var result = orderService.CreateOrder(resource, userId);

    return result.Accept(new FacadeResultVisitor<OrderResource>());
})
.WithName("CreateOrder")
.WithOpenApi();

app.MapPost("/orders/{id}/order-lines", (HttpRequest request, int id, OrderLineResource resource) =>
{
    var userId = getUserIdFromHttpRequest(request);
    var result = orderService.AddOrderLine(id, resource, userId);

    return result.Accept(new FacadeResultVisitor<OrderLineResource>());
})
.WithName("AddOrderLine")
.WithOpenApi();

app.MapGet("/orders/{id}", (int id) =>
{
    var result = orderService.GetOrder(id);

    return result.Accept(new FacadeResultVisitor<OrderResource>());
})
.WithName("GetOrder")
.WithOpenApi();

app.Run();
