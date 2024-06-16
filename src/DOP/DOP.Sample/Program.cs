using DOP;
using DOP.Abstaction;
using DOP.SQLStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDop(opt =>
{
    opt.UseServerSql(x =>
    {
        x.Schema = "DOP";
        x.ConnectionString = "Server=localhost;Database=test;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true";
    });
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/weatherforecast", async (IDopPublisher dopPublisher) =>
    {
        try{
            var test = new Test
            {
                Name = "Test"
            };
            
            await dopPublisher.Publish(test);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

public class Test
{
    public string Name { get; set; }
}