using RouletteService.Repositories;
using RData = RouletteService.Repositories.Data;
using RouletteService.Services.Data;
using System;
using System.Threading.Tasks;
using LanguageExt;

namespace RouletteService.Services
{
    public class BetService : IBetService
    {
        private readonly IBetRepository betRepository;

        public BetService(IBetRepository betRepository)
        {
            this.betRepository = betRepository;
        }


        public async Task<Either<Exception, Identifier>> Create(CreateBet createBet)
        {
            //TODO: check that bet exceeeds min bet amount for game
            var result = Core.Bet.Create(createBet);

            if (result.IsLeft)
            {
                return Either<Exception, Identifier>.Left(((Exception)result));
            }
            //TODO: get player,  update balance, all in one enclosing txn
            var id = await betRepository.Insert(((RData.Bet)result));
            return Either<Exception, Identifier>.Right(new Identifier { Id = id });
        }
    }
}
