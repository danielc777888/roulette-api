// game related functions


using RouletteService.Services.Data;
using RData = RouletteService.Repositories.Data;
using System;
using LanguageExt;


namespace RouletteService.Core
{
    public static class Game
    {
        public static Either<Exception, RData.Game> Create(CreateGame createGame)
        {
            if (createGame.MinBet <= 0)
            {
                return Either<Exception, RData.Game>.Left(new Exception("MinBet must be > 0"));
            }
            var game = new RData.Game
            {
                MinBet = createGame.MinBet,
                CreatedAt = new DateTime()
            };

            return Either<Exception, RData.Game>.Right(game);

        }

    }


}