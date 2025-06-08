using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanderGQL.Models
{
    public class Command
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string HowTo {  get; set; }

        [Required]
        public string CommandLine { get; set; }

        [Required]
        [ForeignKey(nameof(Command.Platform))]
        public Guid PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}
