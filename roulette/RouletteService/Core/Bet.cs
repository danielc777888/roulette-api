// bet related functions


using RouletteService.Services.Data;
using RData = RouletteService.Repositories.Data;
using System;
using LanguageExt;


namespace RouletteService.Core
{
    public static class Bet
    {
        public static Either<Exception, RData.Bet> Create(CreateBet createBet)
        {
            if (createBet.Amount <= 0)
            {
                return Either<Exception, RData.Bet>.Left(new Exception("Amount must be > 0"));
            }
            var bet = new RData.Bet
            {
                Amount = createBet.Amount,
                Number = createBet.Number,
                Type = createBet.Type,
                GameId = createBet.GameId,
                PlayerId = createBet.PlayerId,
                CreatedAt = new DateTime()
            };

            return Either<Exception, RData.Bet>.Right(bet);

        }

    }


}