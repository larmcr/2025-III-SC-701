using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;

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

var myList = new List<string>();

var api = app.MapGroup("/newapi");

api.MapGet("/", () => Results.Redirect("/swagger/index.html"));

api.MapGet("/obtain", () => myList);

api.MapGet("/obtain/{index:int}", ([FromRoute]int index, [FromQuery]bool xml = false) =>
{
    if (index < myList.Count && index > -1)
    {
        var value = myList[index];

        if (xml)
        {
            var xmlSerializer = new XmlSerializer(value.GetType());
            using var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, value);
            return Results.Content(stringWriter.ToString(), "application/xml");
        }
        else
        {
            var json = new { Value = value };
            return Results.Ok(json);
        }
    }
    else
    {
        return Results.NotFound($"Item in [{index}] not found");
    }

});

api.MapPost("/add", ([FromForm] string item) =>
{
    myList.Add(item);
    return Results.Created("/add/{item}", item);
}).DisableAntiforgery();

api.MapPut("/update/{index:int}", ([FromRoute] int index, [FromForm] string value) =>
{
    if (index < myList.Count && index > -1)
    {
        myList[index] = value;
        return Results.Ok($"Item in [{index}] updated to '{value}'");
    }
    else
    {
        return Results.NotFound($"Item in [{index}] not found");
    }
}).DisableAntiforgery();

api.MapDelete("/remove/{index:int}", (int index) =>
{
    if (index < myList.Count && index > -1)
    {
        myList.RemoveAt(index);
        return Results.Ok($"Item in [{index}] deleted");
    }
    else
    {
        return Results.NotFound($"Item in [{index}] not found");
    }
});

api.MapDelete("/remove", ([FromForm] string value) =>
{
    var index = myList.IndexOf(value);
    if (index > -1)
    {
        myList.RemoveAt(index);
        return Results.Ok($"Item in [{index}] deleted");
    }
    else
    { 
        return Results.NotFound($"Item '${value}' not found");
    }
}).DisableAntiforgery();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
