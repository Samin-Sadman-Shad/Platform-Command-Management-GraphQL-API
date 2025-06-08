using CommanderGQL.GraphQL.Inputs;
using CommanderGQL.GraphQL.Playloads;
using CommanderGQL.Models;
using CommanderGQL.Persistance;

namespace CommanderGQL.GraphQL
{
    public class Mutation
    {
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, [Service] CommanderDbContext context)
        {
            if (input == null)
            {
                return new AddPlatformPayload(platform: null);
            }

            var platform = new Platform
            {
                Name = input.Name,
            };

            await context.AddAsync(platform);
            await context.SaveChangesAsync();

            return new AddPlatformPayload(platform: platform);
        }
    }
}
