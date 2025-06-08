using CommanderGQL.Models;
using CommanderGQL.Persistance;

namespace CommanderGQL.GraphQL.Types
{
    public class CommandType:ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Describes the command asscociated with a platform");
            descriptor.Field(command => command.Platform)
                .ResolveWith<Resolver>(resolver => resolver.GetPlatform(default!, default!));

        }

        private class Resolver
        {
            public Platform GetPlatform([Parent] Command command, [Service] CommanderDbContext dbContext)
            {
                return dbContext.Platforms.FirstOrDefault(platform => platform.Id == command.PlatformId);
            }
        }

    }
}
