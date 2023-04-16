namespace logic.Dtos
{
    public class GameDto
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int GameTypeId { get; set; }
        public GameTypeDto GameType { get; set; } = default!;
    }
}
