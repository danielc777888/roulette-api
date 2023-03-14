using Xunit;
using RouletteService.Core;
using RouletteService.Services.Data;


namespace Roulette.UnitTests.Services
{
    public class GameTest
    {

        [Fact]
        public void CreateGame_Success()
        {
            var game = Game.Create(new CreateGame
            {
                MinBet = 5
            });

            Assert.True(game.IsRight, "Game NOT created");
        }

        [Fact]
        public void CreateGame_Failed()
        {
            var game = Game.Create(new CreateGame
            {
                MinBet = 0
            });

            Assert.True(game.IsLeft, "Game creation DID NOT fail");
        }
    }
}