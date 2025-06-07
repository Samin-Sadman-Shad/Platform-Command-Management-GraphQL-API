using CommanderGQL.Models;
using CommanderGQL.Persistance;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        public IQueryable<Platform> GetPlatforms([Service] CommanderDbContext dbContext)
        {
            return dbContext.Platforms;
        }
    }
}
