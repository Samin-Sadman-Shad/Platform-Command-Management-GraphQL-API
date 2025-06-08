using CommanderGQL.Models;
using CommanderGQL.Persistance;

namespace CommanderGQL.GraphQL.Types
{
    public class PlatformType:ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represent any OS or tool that has a command line interface");
            descriptor.Field(p => p.License).Ignore();
            descriptor.Field(p => p.Commands)
                .ResolveWith<Resolver>(resolver => resolver.GetCommand(default!, default!))
                .Description("Commands for this platform");
        }

        private class Resolver
        {
            public IQueryable<Command> GetCommand([Parent] Platform platform, [Service] CommanderDbContext dbContext)
            {
                return dbContext.Commands.Where(command => command.PlatformId == platform.Id);
            }
        }
    }
}
