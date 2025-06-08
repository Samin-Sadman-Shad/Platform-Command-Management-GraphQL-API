using CommanderGQL.Models;
using CommanderGQL.Persistance;
using System;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatforms([Service] CommanderDbContext dbContext)
        {
            return dbContext.Platforms;
        }

        //[UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([Service] CommanderDbContext dbContext)
        {
            return dbContext.Commands;
        }

        //[UseProjection]  //walk the graph to pull back any child object
        //public IQueryable<Platform> GetPlatforms([Service] IDbContextFactory<CommanderDbContext> dbContextFactory)
        //{
        //    using var dbContext = dbContextFactory.CreateDbContext();
        //    return dbContext.Platforms;
        //}
    }
}
