using CommanderGQL.GraphQL;
using CommanderGQL.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommanderDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CommanderConnectionString")));

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

/*app.MapGet("/", () => "Hello World!");*/
app.MapGraphQL();

app.Run();
