// player related functions


using RouletteService.Services.Data;
using RData = RouletteService.Repositories.Data;
using System;
using LanguageExt;


namespace RouletteService.Core
{
    public static class Player
    {
        public static Either<Exception, RData.Player> Create(CreatePlayer createPlayer)
        {
            if (string.IsNullOrEmpty(createPlayer.Name))
            {
                return Either<Exception, RData.Player>.Left(new Exception("Name invalid"));
            }
            var player = new RData.Player
            {
                Name = createPlayer.Name
            };

            return Either<Exception, RData.Player>.Right(player);

        }

    }


}