using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using crosscuttingconcerns.Generics;

namespace dal.DataObjects
{
    [Table("Game", Schema = "GameDB")]
    public class Game: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [ForeignKey("GameType")]
        public int GameTypeId { get; set; }
        public GameType GameType { get; set; } = default!;
    }
}
