using System;

namespace RouletteService.Repositories.Data
{
    public class Spin
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime CreatedAt { get; set; }

        public int GameId { get; set; }
    }
}
