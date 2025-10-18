var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var list = new List<object>();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapPost("/", () => list);

app.MapPut("/", ([FromForm] int quantity, [FromForm] string type) =>
{
    var random = new Random();
    if (type == "int")
    {
        for (; quantity > 0; quantity--)
        {
            list.Add(random.Next());
        }
    }
    else if (type == "float")
    {
        for (; quantity > 0; quantity--)
        {
            list.Add(random.NextSingle());
        }
    }
}).DisableAntiforgery();

app.MapDelete("/", ([FromForm] int quantity) =>
{
    for (; quantity > 0; quantity--)
    {
        list.RemoveAt(0);
    }
}).DisableAntiforgery();

app.MapPatch("/", () =>
{
    return Results.Ok();
});

app.Run();
