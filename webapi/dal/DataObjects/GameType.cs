using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using crosscuttingconcerns.Generics;

namespace dal.DataObjects
{
    [Table("GameType", Schema = "GameDB")]
    public class GameType: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Game> Games { get; set; }

        public GameType()
        {
            Games = new List<Game>();
        }
    }
}
