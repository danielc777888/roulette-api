using System;

namespace RouletteService.Repositories.Data
{
    public class Game
    {
        public int Id { get; set; }
        public int MinBet { get; set; }
        public DateTime CreatedAt { get; set; }
    }


}
