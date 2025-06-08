using CommanderGQL.GraphQL;
using CommanderGQL.Persistance;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using HotChocolate;
using HotChocolate.Data;
using CommanderGQL.GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CommanderDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CommanderConnectionString")));

//builder.Services.AddPooledDbContextFactory<CommanderDbContext>(options =>
//            options.UseSqlServer(builder.Configuration.GetConnectionString("CommanderConnectionString")));

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting();
    //.AddProjections();



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

/*app.MapGet("/", () => "Hello World!");*/
app.MapGraphQL();
/*app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapGraphQL();
});*/

app.UseGraphQLVoyager(
    path: "/graphql-voyager", 
    options: new VoyagerOptions()
    {
        GraphQLEndPoint = "/graphql"
    });

app.Run();
