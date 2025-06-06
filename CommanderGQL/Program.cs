using CommanderGQL.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommanderDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CommanderConnectionString")));


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Hello World!");

app.Run();
