using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    //[GraphQLDescription("Represent any OS or tool that has a command line interface")]
    public class Platform
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        //[GraphQLDescription("Represents a purchased and valid license for the platform")]
        public string? License { get; set; }
        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
