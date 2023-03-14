using System;

namespace RouletteService.Repositories.Data
{
    public class Payout
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
    }

}
