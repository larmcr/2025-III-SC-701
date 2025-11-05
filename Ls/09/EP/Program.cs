var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles(); // index.html, default.html, etc.
app.UseStaticFiles();

app.MapGet("/hello", () => "Hello World!");

app.Run();
