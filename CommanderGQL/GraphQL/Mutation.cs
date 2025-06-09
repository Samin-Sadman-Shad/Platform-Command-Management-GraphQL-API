using CommanderGQL.GraphQL.Inputs;
using CommanderGQL.GraphQL.Payloads;
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

        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [Service] CommanderDbContext context)
        {
            if(input == null)
            {
                return new AddCommandPayload(command: null);
            }

            var command = new Command
            {
                HowTo = input.HowTo,
                CommandLine = input.CommandLine,
                PlatformId = input.PlatformId
            };

            await context.AddAsync(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
    }
}
