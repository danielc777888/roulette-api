using System;

namespace RouletteService.Services.Data
{
    public class CreateBet
    {
        public int Amount { get; set; }
        public int Number { get; set; }

        public string Type { get; set; }

        public int GameId { get; set; }

        public int PlayerId { get; set; }
    }

}
