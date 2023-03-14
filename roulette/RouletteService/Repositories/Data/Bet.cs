using System;

namespace RouletteService.Repositories.Data
{
    public class Bet
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Number { get; set; }

        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
    }
}
