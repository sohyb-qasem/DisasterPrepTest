using System.IO;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async () => {
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "index.html");
    using var streamReader = new StreamReader(filePath);
    var content = await streamReader.ReadToEndAsync();
    return Results.Content(content, "text/html");
});

app.Run();
